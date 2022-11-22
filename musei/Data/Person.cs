using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace musei.Data
{
    public class Person
    {
        public int count;
        public string name;
        public string emailAddress;
        public string optionalSpecialAccomodations;
        public Person(int count, string name, string emailAddress, string optionalSpecialAccomodations)
        {
            this.count = count;
            this.name = name;
            this.emailAddress = emailAddress;
            this.optionalSpecialAccomodations = optionalSpecialAccomodations;
        }

        public Person (int count)
        {
            this.count = count;
            this.name = null;
            this.emailAddress=null;
            this.optionalSpecialAccomodations = null;
        }

        public override string ToString() 
        { 
            return "PERSON-> Name: " + this.name + "; Email Address: " + this.emailAddress + "; Special Accomodations (Optional): " + this.optionalSpecialAccomodations + "\n";
        }
    }
}
