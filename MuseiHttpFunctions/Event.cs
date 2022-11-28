using System;
using Newtonsoft.Json;

namespace MuseiHttpFunctions
{
    public class Event
    {
        public string id { get; set; }

        public string name { get; set; }

        [JsonProperty(PropertyName = "museum")]
        public string museum { get; set; }

        public DateTime startTime { get; set; }

        public string description { get; set; }

        public int price { get; set; }

        public string imageURL { get; set; }

    }
}

