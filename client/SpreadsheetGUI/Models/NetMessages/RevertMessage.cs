/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : CS3505 Final                                                 *
 *                                                                                             *
 *                        File  : Models/NetMessages/RevertMessage.cs                          *
 *                                                                                             *
 *                       Author : Josh Perkins                                                 *
 *                                                                                             *
 *                   Start Date : 04/21/19                                                     *
 *                                                                                             *
 *                      Modtime : 04/21/19                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * Functions:                                                                                  *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

using Newtonsoft.Json;

namespace SS.Models.NetMessages {

    [JsonObject(MemberSerialization.OptIn)]
    public class RevertMessage : DefaultMessage {

        [JsonProperty("cell")]
        public string Cell { get; set; }

        public RevertMessage(string cell) : base("revert") {
            Cell = cell;
        }
    }
}
