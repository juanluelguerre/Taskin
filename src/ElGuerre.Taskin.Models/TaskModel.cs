// -------------------------------------------------------------------
// <copyright Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// -------------------------------------------------------------------

using Newtonsoft.Json;

namespace ElGuerre.Taskin.Models
{
    [JsonObject]
    public class TaskModel : BaseModel<int>
    {
        [JsonProperty]
        public override int Id { get; set; }

        [JsonProperty]
        public string Detail { get; set; }
        [JsonProperty]
        public int Priority { get; set; }
        [JsonProperty]
        public int Effort { get; set; }
        [JsonProperty]
        public int TaskType { get; set; }
    }
}
