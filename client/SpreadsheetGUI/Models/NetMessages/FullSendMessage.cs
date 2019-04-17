/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : CS3505 Final                                                 *
 *                                                                                             *
 *                        File  : Models/NetMessages/FullSendMessage.cs                        *
 *                                                                                             *
 *                       Author : Josh Perkins                                                 *
 *                                                                                             *
 *                   Start Date : 04/16/19                                                     *
 *                                                                                             *
 *                      Modtime : 04/16/19                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * Functions:                                                                                  *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

using Newtonsoft.Json;
using System.Collections.Generic;

namespace SS.Models.NetMessages {

    [JsonObject(MemberSerialization.OptIn)]
    public class FullSendMessage : DefaultMessage {

        [JsonProperty("spreadsheet")]
        public Dictionary<string, string> Cells { get; set; }

        public FullSendMessage(Dictionary<string, string> cells) : base("full send") {
            Cells = cells;
        }
    }
}
