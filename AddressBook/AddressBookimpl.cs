using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AddressBook
{
    class AddressBookimpl:IAddressBook
    {
        //varaibles
        public string firstName;
        public string lastName;
        public string city;
        public string state;
        public string zip;
        public string mobileNumber;
        string NAME_REGEX = "^[a-z]{3,}$";
        string ZIP_REGEX = "^[1-9]{1}[0-9]{5}$";
        string NUMBER_REGEX = "^[0-9]{10}$";
        NLog nLog = new NLog();
        List<Person> personList = new List<Person>();
        Dictionary<string, List<Person>> person = new Dictionary<string, List<Person>>();


        /// <summary>
        /// adding the person in person list
        /// </summary>
        
        
        public void AddPerson()
        {
            Console.WriteLine("please enter number of persons to be added");
            int noOfPersons = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= noOfPersons; i++)
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
                personInfoValidation(firstName,lastName,zip,mobileNumber);
            }
            nLog.LogDebug("Debug sucessfull:AddPerson()");
            Display();

        }
        /// <summary>
        /// Edit the person from existing list
        /// </summary>
        public void EditPerson()
        {
            Console.WriteLine("Enter Edit Person details");
            String edit = Console.ReadLine();
            foreach(Person editPerson in personList)
            {
                if (edit.Equals(editPerson.firstName))
                {
                    Console.WriteLine("Enter Firstname");
                    firstName = editPerson.firstName;
                    Console.WriteLine("Enter Lastname");
                    editPerson.lastName = Console.ReadLine();
                    Console.WriteLine("Enter city");
                    editPerson.city = Console.ReadLine();
                    Console.WriteLine("Enter state");
                    editPerson.state = Console.ReadLine();
                    Console.WriteLine("Enter Zip");
                    editPerson.zip = Console.ReadLine();
                    Console.WriteLine("Enter Mobile number");
                    editPerson.mobileNumber = Console.ReadLine();
                }
            }
            nLog.LogDebug("Debug sucessfull:EditPerson()");
            Display();
        }
        /// <summary>
        /// Deletes the person from existing list
        /// </summary>
        public void DeletePerson()
        {
            Console.WriteLine("Enter your Delete person details");
            string search = Console.ReadLine();
            int index = 0;
            Console.WriteLine("Size before deleting::" + personList.Count);
            foreach (Person delPerson in personList)
            {
                if (search.Equals(delPerson.firstName)){
                    index = personList.IndexOf(delPerson);
                    personList.RemoveAt(index);
                    Console.WriteLine("Size after deletion::"+personList.Count);
                    nLog.LogDebug("Debug sucessfull:DeletePerson()");
                    break;
                }
            }
        }
        /// <summary>
        /// Displays this list.
        /// </summary>
        public void Display()
        {
            foreach (Person person in personList)
                Console.WriteLine(person.toString());
        }

        /// <summary>
        /// validing person details using regex
        /// </summary>
        /// <param name="firstname">The firstname.</param>
        /// <param name="lastname">The lastname.</param>
        /// <param name="zipcode">The zipcode.</param>
        /// <param name="mobileNumber">The mobile number.</param>
        
        public void personInfoValidation(string firstname,string lastname,string zipcode,string mobileNumber)
        {
            if (Regex.IsMatch(firstname, NAME_REGEX) && (Regex.IsMatch(lastName, NAME_REGEX)) && (Regex.IsMatch(zipcode, ZIP_REGEX)) && (Regex.IsMatch(mobileNumber, NUMBER_REGEX)))
            {
                personList.Add(new Person(firstName, lastName, city, state, zip, mobileNumber));
                person.Add(firstName, personList);
            }
            else
            {
                nLog.LogError("Please enter valid details");
            }
        }
    }
}
