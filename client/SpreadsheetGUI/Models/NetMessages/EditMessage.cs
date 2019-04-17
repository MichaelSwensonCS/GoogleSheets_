/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : CS3505 Final                                                 *
 *                                                                                             *
 *                        File  : Models/NetMessages/EditMessage.cs                            *
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
    public class EditMessage : DefaultMessage {

        [JsonProperty("cell")]
        public string Cell { get; set; }

        [JsonProperty("value")]
        public string Contents { get; set; }

        [JsonProperty("dependencies")]
        public List<string> Dependencies { get; set; }

        public EditMessage(string cell, string contents, List<string> dependencies) : base("edit") {
            Cell = cell;
            Contents = contents;
            Dependencies = dependencies;
        }
    }
}
