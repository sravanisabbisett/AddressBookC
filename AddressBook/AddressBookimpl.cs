using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AddressBook
{
    class AddressBookimpl
    {
        public string firstName;
        public string lastName;
        public string city;
        public string state;
        public string zip;
        public string mobileNumber;
        List<Person> personList = new List<Person>();


        
        public void AddUser()
        {
            Console.WriteLine("Enter Firstname");
            firstName = Console.ReadLine();
            Console.WriteLine("Enter Lastname");
            lastName = Console.ReadLine();
            Console.WriteLine("Enter city");
            city = Console.ReadLine();
            Console.WriteLine("Enter state");
            state = Console.ReadLine();
            Console.WriteLine("Enter Zip");
            zip = Console.ReadLine();
            Console.WriteLine("Enter Mobile number");
            mobileNumber = Console.ReadLine();
            personList.Add(new Person(firstName, lastName, city, state, zip, mobileNumber));
            foreach (Person addPerson in personList)
                Console.WriteLine(addPerson.toString());
            
        }
    }
}
