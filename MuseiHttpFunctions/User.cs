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

        public List<int> followedMuseums { get; set; }

        public Boolean isAdmin { get; set; } = false;

        public List<Booking> eventBookings { get; set; }
    }
}
