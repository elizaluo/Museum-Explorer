using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace musei.Data
{
    public class PersonCard
    {
        private String name;
        private String emailAddress;
        private String optionalSpecialAccomodations;
        public PersonCard(String name, String emailAddress, String optionalSpecialAccomodations)
        {
            this.name = name;
            this.emailAddress = emailAddress;
            this.optionalSpecialAccomodations = optionalSpecialAccomodations;
        }

        public String getName() { return name; }
        public String getEmailAddress() { return emailAddress; }
        public String getOptionalSpecialAccomodations() { return optionalSpecialAccomodations; }

        public void setName(String name) { this.name = name; }
        public void setEmailAddress(String emailAddress) { this.emailAddress = emailAddress; }
        public void setOptionalSpecialAccomodations(String optionalSpecialAccomodations) { this.optionalSpecialAccomodations = optionalSpecialAccomodations; }
    }
}
