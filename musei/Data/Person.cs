using System;

namespace musei.Data
{
    public class Person
    {
        public int count { get; set; }
        public string name { get; set; }
        public string emailAddress { get; set; }
        public string optionalSpecialAccomodations { get; set; }

        public Person()
        {
        }

        public override string ToString()
        {
            return "PERSON-> Name: " + this.name + "; Email Address: " + this.emailAddress + "; Special Accomodations (Optional): " + this.optionalSpecialAccomodations + "\n";
        }
    }
}