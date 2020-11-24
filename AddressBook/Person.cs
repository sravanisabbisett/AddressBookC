using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook
{
    class Person
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string city { get; set; } 
        public string state { get; set; }
        public string zip { get; set; }
        public string mobileNumber { get; set; }

        public Person(string firstName,string lastName,string city,string state,string zip,string mobileNumber)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.city = city;
            this.state = state;
            this.zip = zip;
            this.mobileNumber = mobileNumber;
        }

        public string toString()
        {
            return "FirstName::" + firstName + ",LastName::" + lastName + ",City::" + city + ",State::" + state + ",Zip::" + zip + ",MobileNumber" + mobileNumber;
        }

    }
}
