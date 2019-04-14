/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : CS3505 Final                                                 *
 *                                                                                             *
 *                        File  : Models/NetMessages/DefaultMessage.cs                         *
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

namespace SS.Models.NetMessages {

    [JsonObject(MemberSerialization.OptIn)]
    public class DefaultMessage {

        [JsonProperty("type")]
        public string Type { get; set; }

        public DefaultMessage(string type) {
            Type = type;
        }
    }
}
