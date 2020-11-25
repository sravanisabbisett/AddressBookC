using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

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
                personList.Add(new Person(firstName, lastName, city, state, zip, mobileNumber));
                person.Add(firstName, personList);
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
    }
}
