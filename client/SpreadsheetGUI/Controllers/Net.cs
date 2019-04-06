/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : PS7                                                          *
 *                                                                                             *
 *                        File  : Controllers/Net.cs                                           *
 *                                                                                             *
 *                   Start Date : 11/03/18                                                     *
 *                                                                                             *
 *                      Modtime : 04/06/19                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * Functions:                                                                                  *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using SS.Misc;
using SS.Models;

namespace SS.Controllers {

    /// <summary>
    /// Delegate that is used when a connection is made.
    /// </summary>
    public delegate void NetworkAction(SocketState state);

    /// <summary>
    /// Handles a connection attempt.
    /// </summary>
    /// <param name="server">The server address.</param>
    public delegate void ConnectionHandler(string server);

    /// <summary>
    /// The Net class helps with all basic networking related tasks
    /// </summary>
    public static class Net {

        /// <summary>
        /// The default port used in the network module.
        /// </summary>
        public const int DEFAULT_PORT = 2112;

        /// <summary>
        /// Creates a new socket object from the specified hostname.
        /// </summary>
        /// <param name="hostname">The hostname to try to connect to.</param>
        /// <param name="ip">The IP address that is created.</param>
        /// <returns></returns>
        public static Socket CreateSocket(string hostname, out IPAddress ip) {
            Socket socket = null;
            ip = null;
            IPHostEntry ipHostInfo;
            try {
                ipHostInfo = Dns.GetHostEntry(hostname);
                bool foundIPV4 = false;
                foreach (IPAddress addr in ipHostInfo.AddressList) {
                    if (addr.AddressFamily != AddressFamily.InterNetworkV6) {
                        foundIPV4 = true;
                        ip = addr;
                        break;
                    }
                }

                if (!foundIPV4) {
                    throw new ArgumentException("Invalid address");
                }

                socket = new Socket(ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                socket.SetSocketOption(SocketOptionLevel.IPv6, SocketOptionName.IPv6Only, false);
            }
            catch (Exception e) {
                if (Log.Enabled) {
                    Log.WriteLine("Net: ERROR - Unable to create socket", true);
                    Log.WriteLine($"\t messsage: {e.Message}", false);
                }

                throw new ArgumentException("Invalid address");
            }

            socket.NoDelay = true;
            return socket;
        }

        /// <summary>
        /// Attempts to connect to a server.
        /// </summary>
        /// <param name="callback">The function callback to invoke when the connection completes.</param>
        /// <param name="hostname">The name of the host to connect to.</param>
        /// <param name="token">The token to cancel a connection if needed.</param>
        /// <returns></returns>
        public static Socket ConnectToServer(NetworkAction callback, string hostname, CancellationToken token) {
            try {
                Socket socket = CreateSocket(hostname, out IPAddress ip);
                SocketState ss = new SocketState(socket, callback, token);

                ss.Socket.BeginConnect(ip, DEFAULT_PORT, ConnectedCallback, ss);
                return socket;
            }
            catch (Exception e) {
                throw e;
            }
        }

        /// <summary>
        /// Called when the socket connects to the server.
        /// </summary>
        /// <param name="ar"></param>
        private static void ConnectedCallback(IAsyncResult ar) {
            SocketState ss = ar.AsyncState as SocketState;

            if (ss != null) {
                if (ss.Socket.Connected) {
                    try {
                        ss.Socket.EndConnect(ar);
                        ss.Callback(ss);
                    }
                    catch (Exception e) {
                        if (Log.Enabled) {
                            Log.WriteLine("Net: ERROR - Unable to connect to server", true);
                            Log.WriteLine($"\t messsage: {e.Message}", false);
                        }

                        SetErrorState(ss, e.Message);
                        ss.Callback(ss);
                    }
                }

                else {
                    SetErrorState(ss, "Unable to reach server.");
                    ss.Callback(ss);
                }
            }
        }

        /// <summary>
        /// Gets more data from the server.
        /// </summary>
        /// <param name="state">The socket state object.</param>
        public static void GetData(SocketState state) {
            state.Socket.BeginReceive(state.Buffer, 0, state.Buffer.Length, SocketFlags.None, ReceiveCallback, state);
        }

        /// <summary>
        /// Called when data is received from the server.
        /// </summary>
        /// <param name="ar"></param>
        private static void ReceiveCallback(IAsyncResult ar) {
            SocketState ss = ar.AsyncState as SocketState;

            if (ss != null) {
                if (ss.Socket.Connected) {

                    int bytesRead = 0;
                    try {
                        bytesRead = ss.Socket.EndReceive(ar);
                    }
                    catch (Exception e) {
                        SetErrorState(ss, e.Message);
                        ss.Callback(ss);
                    }

                    if (ss.CancelRequested()) {
                        EndConnection(ss.Socket);
                        ss = null;
                        return;
                    }

                    if (bytesRead > 0) {
                        string temp = System.Text.Encoding.UTF8.GetString(ss.Buffer, 0, bytesRead);
                        ss.SB.Append(temp);
                        ss.Callback(ss);
                    }
                }

                else {
                    SetErrorState(ss, "Unable to reach server.");
                    ss.Callback(ss);
                }
            }
        }

        /// <summary>
        /// Sends data over a socket.
        /// </summary>
        /// <param name="socket">The socket to transmit with.</param>
        /// <param name="data">The data to be sent.</param>
        public static void Send(Socket socket, String data) {
            try {
                byte[] bytes = Encoding.ASCII.GetBytes(data);
                socket.BeginSend(bytes, 0, bytes.Length, SocketFlags.None, SendCallback, socket);
            }
            catch (Exception e) {
                if (socket.Connected) {
                    socket.Close();
                }
            }
        }

        /// <summary>
        /// Called when sending data to the server begins.
        /// </summary>
        /// <param name="ar"></param>
        private static void SendCallback(IAsyncResult ar) {
            Socket ss = ar.AsyncState as Socket;
            if (ss != null) {
                if (ss.Connected) {
                    try {
                        ss.EndSend(ar);
                    }
                    catch (Exception e) {
                        if (ss.Connected) {
                            ss.Close();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Helper method that encapsulates creating an error state.
        /// </summary>
        /// <param name="state">The SocketState to update.</param>
        /// <param name="message">The error message to pass along.</param>
        private static void SetErrorState(SocketState state, string message) {
            state.Error = true;
            state.ErrorMessage = message;
            if (state.Socket.Connected) {
                state.Socket.Close();
            }
        }

        /// <summary>
        /// Starts a TcpListener and listens for new connections.
        /// </summary>
        /// <param name="callback">The function callback to invoke when a new connection is received.</param>
        public static void ServerAwaitingClientLoop(NetworkAction callback) {
            ConnectState cs = new ConnectState(new TcpListener(IPAddress.Any, Net.DEFAULT_PORT), callback);
            cs.Listener.Start();
            cs.Listener.BeginAcceptSocket(AcceptNewClient, cs);
        }

        /// <summary>
        /// Called whena new connection request is received.
        /// </summary>
        /// <param name="ar"></param>
        public static void AcceptNewClient(IAsyncResult ar) {
            ConnectState cs = ar.AsyncState as ConnectState;
            if (cs != null) {
                Socket s = cs.Listener.EndAcceptSocket(ar);
                SocketState ss = new SocketState(s, cs.Callback, CancellationToken.None);
                cs.Callback(ss);

                // continue event loop
                cs.Listener.BeginAcceptSocket(AcceptNewClient, cs);
            }
        }

        /// <summary>
        /// Helper method that terminates a connection.
        /// </summary>
        /// <param name="s">The socket to terminate.</param>
        public static void EndConnection(Socket s) {
            if (s.Connected) {
                s.Shutdown(SocketShutdown.Both);
                s.Close();
            }
        }
    }
}