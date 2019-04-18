/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : PS7                                                          *
 *                                                                                             *
 *                        File  : Models/Net/SocketState.cs                                    *
 *                                                                                             *
 *                   Start Date : 11/04/18                                                     *
 *                                                                                             *
 *                      Modtime : 04/18/19                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * Functions:                                                                                  *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

using SS.Controllers;
using SS.Models.NetMessages;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace SS.Models {

    /// <summary>
    /// Represents a single socket with it's own message buffer.
    /// </summary>
    public class SocketState {

        public enum MessageType {
            None,
            Initial,
            Open,
            Edit
        }

        private CancellationToken _token;

        /// <summary>
        /// The user ID associated with the socket.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// The associated socket.
        /// </summary>
        public Socket Socket { get; private set; }

        /// <summary>
        /// The data buffer of the connection.
        /// </summary>
        public byte[] Buffer { get; set; }
        private int _bufferLength = 4096;

        /// <summary>
        /// The callback function used when a connection is established.
        /// </summary>
        public NetworkAction Callback { get; set; }

        /// <summary>
        /// Responsible for holding data when a connection streams back.
        /// </summary>
        public StringBuilder SB { get; private set; }

        /// <summary>
        /// Determines what the receving data message would be.
        /// </summary>
        public MessageType RecMessage { get; set; }

        /// <summary>
        /// Messages that are to be sent out with a socket.
        /// </summary>
        public List<DefaultMessage> OutboundMessages { get; set; }

        /// <summary>
        /// Determines whether an error has occurred.
        /// </summary>
        public bool Error { get; set; }

        /// <summary>
        /// The error message if an error has occurred.
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Basic constructor.
        /// </summary>
        /// <param name="s">The socket to associate with.</param>
        /// <param name="callback">The callback delegate to use when a connection is made.</param>
        /// <param name="token">The cancelation token associated with the socket.</param>
        public SocketState(Socket s, NetworkAction callback, CancellationToken token) {
            _token = token;
            Socket = s;
            Callback = callback;

            Buffer = new byte[_bufferLength];
            SB = new StringBuilder();
            RecMessage = MessageType.None;

            OutboundMessages = new List<DefaultMessage>();

            Error = false;
            ErrorMessage = "";
        }

        /// <summary>
        /// Checks to see if the connection has been requested to end.
        /// </summary>
        /// <returns></returns>
        public bool CancelRequested() {
            return _token.IsCancellationRequested;
        }
    }
}