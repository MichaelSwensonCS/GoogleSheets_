﻿/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : CS3505 Final                                                 *
 *                                                                                             *
 *                        File  : Models/NetMessages/OpenMessage.cs                            *
 *                                                                                             *
 *                       Author : Josh Perkins                                                 *
 *                                                                                             *
 *                   Start Date : 04/06/19                                                     *
 *                                                                                             *
 *                      Modtime : 04/14/19                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * Functions:                                                                                  *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

using Newtonsoft.Json;

namespace SS.Models.NetMessages {

    [JsonObject(MemberSerialization.OptIn)]
    public class OpenMessage : DefaultMessage {

        [JsonProperty("name")]
        public string SpreadsheetName { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        public OpenMessage(string name, string username, string password) : base("open") {
            SpreadsheetName = name;
            Username = username;
            Password = password;
        }
    }
}
