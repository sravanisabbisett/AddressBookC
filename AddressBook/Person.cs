using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook
{
    class Person
    {
        //variables and getter and setters
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string city { get; set; } 
        public string state { get; set; }
        public string zip { get; set; }
        public string mobileNumber { get; set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="city">The city.</param>
        /// <param name="state">The state.</param>
        /// <param name="zip">The zip.</param>
        /// <param name="mobileNumber">The mobile number.</param>
        public Person(string firstName,string lastName,string city,string state,string zip,string mobileNumber)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.city = city;
            this.state = state;
            this.zip = zip;
            this.mobileNumber = mobileNumber;
        }


        /// <summary>
        /// To print the elements in list
        /// </summary>
        /// <returns></returns>
        public string toString()
        {
            return "FirstName::" + firstName + ",LastName::" + lastName + ",City::" + city + ",State::" + state + ",Zip::" + zip + ",MobileNumber::" + mobileNumber;
        }

    }
}
