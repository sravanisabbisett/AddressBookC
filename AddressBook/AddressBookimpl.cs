using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        int checkForDuplicate = 0;
        //constants
        public const string NAME_REGEX = "^[a-z]{3,}$";
        public const string ZIP_REGEX = "^[1-9]{1}[0-9]{5}$";
        public const string NUMBER_REGEX = "^[0-9]{10}$";
       
        NLog nLog = new NLog();
        List<Person> personList = new List<Person>();
        Dictionary<string, List<Person>> person = new Dictionary<string, List<Person>>();
        bool i = true;


        /// <summary>
        /// adding the person in person list
        /// </summary>
        
        
        public void AddPerson()
        {
            i = true;
            while (i)
            {
                try
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
                    CheckForDuplicate(firstName);
                    personInfoValidation(firstName, lastName, zip, mobileNumber);
                    Console.WriteLine("want to add more contacts then press 1 or press other than 1");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    if (choice == 1)
                        AddPerson();
                    else
                        i = false;
                        
                }catch(System.FormatException)
                {

                    throw new AddressBookException("Please enter valid number");
                }
                  
            }
            
            
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
            if (checkForDuplicate==0 &&Regex.IsMatch(firstname, NAME_REGEX) && (Regex.IsMatch(lastName, NAME_REGEX)) && (Regex.IsMatch(zipcode, ZIP_REGEX)) && (Regex.IsMatch(mobileNumber, NUMBER_REGEX)))
            {
                personList.Add(new Person(firstName, lastName, city, state, zip, mobileNumber));
                person.Add(firstName, personList);
            }
            else
            {
                Console.WriteLine("Invalid details");
                nLog.LogError("Please enter valid details");
            }
        }

        /// <summary>
        /// checks is the person is already exists or not
        /// </summary>
        /// <param name="firstname">The firstname.</param>
        public void CheckForDuplicate(string firstname)
        {
            if (person.ContainsKey(firstname))
            {

                Console.WriteLine("Contact already exists");
                checkForDuplicate = 1;
                AddPerson();
            }
            
        }

        public void SearchPerson()
        {
            Console.WriteLine("Choose you want to search by city or state\n" + "Press 1 for city\n" + "Press 2 for state");
            try
            {
                int choose = Convert.ToInt32(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        Console.WriteLine("Enter city name to search");
                        string searchCity = Console.ReadLine();
                        foreach (Person person in personList.FindAll(s => s.city.Equals(searchCity)).ToList())
                        {
                            Console.WriteLine(person.toString());
                        }
                        break;
                    case 2:
                        Console.WriteLine("Enter state name to search");
                        string searchState = Console.ReadLine();
                        foreach (Person person in personList.FindAll(s => s.state.Equals(searchState)).ToList())
                        {
                            Console.WriteLine(person.toString());
                        }
                        break;
                }
            }
            catch (System.FormatException)
            {
                throw new AddressBookException("Please enter correct input");
            }
        }

        public void CountPerson()
        {
            Console.WriteLine("Choose how you want to count by city or state\n" + "Press 1 for city\n" + "Press 2 for state");
            try
            {
                int choose = Convert.ToInt32(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        Console.WriteLine("Enter city name to search");
                        string countCity = Console.ReadLine();
                        int countByCity = personList.FindAll(s => s.city.Equals(countCity)).Count;
                        Console.WriteLine("No of persons present in addressbook for " + countCity + " is::" + countByCity);
                        break;
                    case 2:
                        Console.WriteLine("Enter state name to search");
                        string countState = Console.ReadLine();
                        int countByState = personList.FindAll(s => s.state.Equals(countState)).Count;
                        Console.WriteLine("No of persons present in addressbook for " + countState + " is::" + countByState);
                        break;
                }
            }
            catch (System.FormatException)
            {
                throw new AddressBookException("Please enter correct input");
            }
        }
    }
}
