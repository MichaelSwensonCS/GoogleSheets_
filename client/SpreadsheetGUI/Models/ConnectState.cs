/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : PS8                                                          *
 *                                                                                             *
 *                        File  : Models/Net/ConnectState.cs                                   *
 *                                                                                             *
 *                   Start Date : 11/18/18                                                     *
 *                                                                                             *
 *                      Modtime : 03/28/19                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * Functions:                                                                                  *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

using SS.Controllers;
using System.Net;
using System.Net.Sockets;

namespace SS.Models {

    /// <summary>
    /// Represents the state of a connection for a server.
    /// </summary>
    public class ConnectState {

        /// <summary>
        /// The associated TCP listener.
        /// </summary>
        public TcpListener Listener { get; private set; }

        /// <summary>
        /// The callback function used when a connection is established.
        /// </summary>
        public NetworkAction Callback { get; set; }

        /// <summary>
        /// Basic constructor.
        /// </summary>
        /// <param name="listener">The TCP listener to associate with this state.</param>
        /// <param name="callback">The callback function to use.</param>
        public ConnectState(TcpListener listener, NetworkAction callback) {
            Listener = listener;
            Callback = callback;
        }
    }
}