/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : PS7                                                          *
 *                                                                                             *
 *                        File  : Misc/Log.cs                                                  *
 *                                                                                             *
 *                   Start Date : 11/03/18                                                     *
 *                                                                                             *
 *                      Modtime : 04/06/19                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * Functions:                                                                                  *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

using System;
using System.IO;

namespace SS.Misc {

    /// <summary>
    /// Manages creation and management of log files.
    /// </summary>
    public static class Log {

        private static string _path = null;
        private static string _lastDate = "";

        /// <summary>
        /// Determines whether the logger has been enabled.
        /// </summary>
        public static bool Enabled { get; private set; } = false;

        /// <summary>
        /// Open a log file to write out to. If a valid path is provided but the file does not exist
        /// then the file will be created.
        /// </summary>
        /// <param name="path">Path to the log file.</param>
        public static void Start(string path) {
            if (string.IsNullOrEmpty(path)) { return; }

            Stop();

            _path = path;

            try {
                WriteLine("Log started.", true);
                WriteLine("", false);
                Enabled = true;
            }
            catch (Exception e) {
                _path = null;
                throw e;
            }
        }

        /// <summary>
        /// Writes the provided message to the log file.
        /// </summary>
        /// <param name="msg">The message to write.</param>
        /// <param name="timestamp">Determines whether the line should be time stamped.</param>
        public static void WriteLine(string msg, bool timestamp) {
            if (_path == null) { return; }

            msg = timestamp ? DoTimeStamp(msg) : msg;
            using (StreamWriter file = new StreamWriter(_path, true)) {
                file.WriteLine(msg);
            }
        }

        /// <summary>
        /// Closes the currently open log file.
        /// </summary>
        public static void Stop() {
            if (_path != null) { _path = null; }
        }

        /// <summary>
        /// Small helper method to prepend a timestamp to a message.
        /// </summary>
        /// <param name="msg">The original message.</param>
        /// <returns>Timestamped message.</returns>
        public static string DoTimeStamp(string msg) {
            if (string.IsNullOrEmpty(msg)) { return msg; }
            _lastDate = $"{DateTime.Now.ToString("G")} - ";
            return _lastDate + msg;
        }

        /// <summary>
        /// Pads a given message so it can align with other timestamped messages.
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static string DoPaddedMessage(string msg) {
            string padding = new string(' ', _lastDate.Length);
            return padding + msg;
        }
    }
}