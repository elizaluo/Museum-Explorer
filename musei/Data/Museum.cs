using System;
using Newtonsoft.Json;

namespace musei.Data
{
	public class Museum
	{
        public string id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string name { get; set; }

        public string address { get; set; }

        public string hours { get; set; }

        public List<string> events { get; set; }
    }
}

