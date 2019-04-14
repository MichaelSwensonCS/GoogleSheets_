/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : CS3505 Final                                                 *
 *                                                                                             *
 *                        File  : Models/NetMessages/ListMessage.cs                            *
 *                                                                                             *
 *                       Author : Josh Perkins                                                 *
 *                                                                                             *
 *                   Start Date : 04/14/19                                                     *
 *                                                                                             *
 *                      Modtime : 04/14/19                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * Functions:                                                                                  *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

using Newtonsoft.Json;
using System.Collections.Generic;

namespace SS.Models.NetMessages {

    [JsonObject(MemberSerialization.OptIn)]
    public class ListMessage : DefaultMessage {

        [JsonProperty("spreadsheets")]
        public List<string> Spreadsheets { get; set; }

        public ListMessage(List<string> spreadsheets) : base("list") {
            Spreadsheets = spreadsheets;
        }
    }
}
