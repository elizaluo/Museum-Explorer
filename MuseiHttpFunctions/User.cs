using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MuseiHttpFunctions
{
    public class User
    {
        public string id { get; set; }

        public string name { get; set; }

        public DateTime birthDate { get; set; }

        public string password { get; set; }

        public List<string> followedMuseums { get; set; } = new List<string>();

        public Boolean isAdmin { get; set; } = false;

        public List<Booking> eventBookings { get; set; } = new List<Booking>();
    }
}
