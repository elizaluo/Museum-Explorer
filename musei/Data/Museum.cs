using System;

namespace musei.Data
{
	public class Museum
	{
        public string id { get; set; }

        public string name { get; set; }

        public string address { get; set; }

        public string hours { get; set; }

        public List<string> events { get; set; }

        public string imageURL { get; set; }
    }
}

