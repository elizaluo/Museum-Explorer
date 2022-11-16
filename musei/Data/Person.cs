using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace musei.Data
{
    public class Person
    {
        private string name;
        private string emailAddress;
        private string optionalSpecialAccomodations;
        public Person(string name, string emailAddress, string optionalSpecialAccomodations)
        {
            this.name = name;
            this.emailAddress = emailAddress;
            this.optionalSpecialAccomodations = optionalSpecialAccomodations;
        }

        public Person ()
        {
            this.name = null;
            this.emailAddress=null;
            this.optionalSpecialAccomodations = null;
        }

        public override string ToString() 
        { 
            return "PERSON-> Name: " + this.name + "; Email Address: " + this.emailAddress + "; Special Accomodations (Optional): " + this.optionalSpecialAccomodations + "\n";
        }

        public string getName() { return name; }
        public string getEmailAddress() { return emailAddress; }
        public string getOptionalSpecialAccomodations() { return optionalSpecialAccomodations; }

        public void setName(string name) { this.name = name; }
        public void setEmailAddress(string emailAddress) { this.emailAddress = emailAddress; }
        public void setOptionalSpecialAccomodations(string optionalSpecialAccomodations) { this.optionalSpecialAccomodations = optionalSpecialAccomodations; }
    }
}
