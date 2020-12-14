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
        
        //constants
        public const string NAME_REGEX = "^[a-z]{3,}$";
        public const string ZIP_REGEX = "^[1-9]{1}[0-9]{5}$";
        public const string NUMBER_REGEX = "^[0-9]{10}$";
        public string cityFile = "City.txt";
        public string stateFile = "State.txt";

        NLog nLog = new NLog();
        List<Person> personList = new List<Person>();
        ReadWrite readWrite = new ReadWrite();
        Dictionary<string, string> cityDictionary = new Dictionary<string, string>();
        Dictionary<string ,string> stateDictionary = new Dictionary<string, string>();
        bool i = true;
       
       
        /// <summary>
        /// adding the person in person list
        /// </summary>
        public void AddPerson(string filename)
        {
            ReadFile(filename);
            Console.WriteLine(personList.Count);
            i = true;
            while (i)
            {
                try
                {
                    Console.WriteLine("Enter Firstname");
                    firstName = Console.ReadLine();
                    if (CheckForDuplicate(firstName))
                    {
                        Console.WriteLine("Person already exists,Please Add Again\n");
                        AddPerson(filename);
                    }
                    else
                    {
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
                        PersonInfoValidation(firstName, lastName, zip, mobileNumber);
                        WriteFile(filename,personList);
                        Console.WriteLine("want to add more contacts then press 1 or press other than 1");
                        int choice = Convert.ToInt32(Console.ReadLine());
                        if (choice == 1)
                            AddPerson(filename);
                        else
                            i = false;
                    }      
                }catch(System.FormatException formatException)
                {
                    throw formatException;
                }
                catch (AddressBookException)
                {
                    throw new AddressBookException("Please enter valid number");
                }
            }
        }
        /// <summary>
        /// Edit the person from existing list
        /// </summary>
        public void EditPerson(string filename)
        {
            ReadFile(filename);
            Console.WriteLine("Enter Edit Person details");
            String edit = Console.ReadLine();
            foreach(Person editPerson in personList)
            {
                if (edit.Equals(editPerson.firstName))
                {
                    Console.WriteLine("Please select the option to edit\n" + "1)city\n" + "2)state\n" + "3)zip\n" + "4)Number");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    firstName = editPerson.firstName;
                    editPerson.lastName = editPerson.lastName;
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter city");
                            editPerson.city = Console.ReadLine();
                            break;
                        case 2:
                            Console.WriteLine("Enter state");
                            editPerson.state = Console.ReadLine();
                            break;
                        case 3:
                            Console.WriteLine("Enter Zip");
                            editPerson.zip = Console.ReadLine();
                            break;
                        case 4:
                            Console.WriteLine("Enter Mobile number");
                            editPerson.mobileNumber = Console.ReadLine();
                            break;
                        default:
                            Console.WriteLine("Please enter correct option");
                            break;
                    }
                }
            }
            nLog.LogDebug("Debug sucessfull:EditPerson()");
            WriteFile(filename, personList);
            Display(filename);
        }
        /// <summary>
        /// Deletes the person from existing list
        /// </summary>
        public void DeletePerson(string filename)
        {
            ReadFile(filename);
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
            WriteFile(filename, personList);
        }

        /// <summary>
        /// Displays this list.
        /// </summary>
        public void Display(string filename)
        {
            ReadFile(filename);
            if (personList.Count == 0) 
                Console.WriteLine("No contact data to display ");
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
        
        public void PersonInfoValidation(string firstname,string lastname,string zipcode,string mobileNumber)
        {
            if (Regex.IsMatch(firstname, NAME_REGEX) && (Regex.IsMatch(lastName, NAME_REGEX)) && (Regex.IsMatch(zipcode, ZIP_REGEX)) && (Regex.IsMatch(mobileNumber, NUMBER_REGEX)))
            {
                cityDictionary = readWrite.ReadFromTxtToDictionary(cityFile);
                stateDictionary=readWrite.ReadFromTxtToDictionary(stateFile);
                personList.Add(new Person(firstName, lastName, city, state, zip, mobileNumber));
                cityDictionary.Add(firstname, city);
                stateDictionary.Add(firstname, state);
                readWrite.WriteDictionaryToTxt(cityFile, cityDictionary);
                readWrite.WriteDictionaryToTxt(stateFile, stateDictionary);
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
        public bool CheckForDuplicate(string firstname)
        {
            cityDictionary = readWrite.ReadFromTxtToDictionary(cityFile);
            if (cityDictionary.ContainsKey(firstname))
                return true;
            else
                return false;
        }

        /// <summary>
        /// search the person in the addressbook by using city or state
        /// </summary>
        /// <exception cref="AddressBookException">Please enter correct input</exception>
        
        public void SearchPerson(string filename)
        {
            ReadFile(filename);
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
                            Console.WriteLine(person.toString());
                        break;
                    case 2:
                        Console.WriteLine("Enter state name to search");
                        string searchState = Console.ReadLine();
                        foreach (Person person in personList.FindAll(s => s.state.Equals(searchState)).ToList())
                            Console.WriteLine(person.toString());
                        break;
                }
            }
            catch (System.FormatException formatException)
            {
                throw formatException;
            }
            catch (AddressBookException)
            {
                throw new AddressBookException("Please enter valid number");
            }
        }

        /// <summary>
        /// Count the persons in address book by using city or state
        /// </summary>
        /// <exception cref="AddressBookException">Please enter correct input</exception>
        
        public void CountPerson(string filename)
        {
            string count=null;
            int countPersons=0;
            ReadFile(filename);
            Console.WriteLine("Choose how you want to count by city or state\n" + "Press 1 for city\n" + "Press 2 for state");
            try
            {
                int choose = Convert.ToInt32(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        Console.WriteLine("Enter city name to search");
                        count = Console.ReadLine();
                        countPersons = personList.FindAll(s => s.city.Equals(count)).Count;
                        break;
                    case 2:
                        Console.WriteLine("Enter state name to search");
                        count = Console.ReadLine();
                        countPersons = personList.FindAll(s => s.state.Equals(count)).Count;
                        break;
                }
            }
            catch (System.FormatException formatException)
            {
                throw formatException;
            }
            catch (AddressBookException)
            {
                throw new AddressBookException("Please enter valid number");
            }
            Console.WriteLine("No of persons present in addressbook for " + count + " is::" + countPersons);
        }

        /// <summary>
        /// view the persons in addressbook by using city or state
        /// </summary>
        public void ViewAddressBook()
        {
            Console.WriteLine("Choose how you want to view by city or state\n" + "Press 1 for city\n" + "Press 2 for state");
            try
            {
                cityDictionary = readWrite.ReadFromTxtToDictionary(cityFile);
                stateDictionary = readWrite.ReadFromTxtToDictionary(stateFile);
                int choose = Convert.ToInt32(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        Console.WriteLine("Enter city name to view person");
                        string viewCity = Console.ReadLine();
                        var searchCity = cityDictionary.Where(x => x.Value.Equals(viewCity));
                        foreach (var result in searchCity)
                            Console.WriteLine("Firstname:{0} , City:{1}",result.Key, result.Value);
                        break;
                    case 2:
                        Console.WriteLine("Enter state name to view person");
                        string viewState = Console.ReadLine();
                        var searchState = stateDictionary.Where(x => x.Value.Equals(viewState));
                        foreach (var result in searchState)
                            Console.WriteLine("Firstname:{0} , State:{1}", result.Key, result.Value);
                        break;
                }
            }
            catch (System.FormatException formatException)
            {
                throw formatException;
            }
            catch (AddressBookException)
            {
                throw new AddressBookException("Please enter valid number");
            }
        }

        /// <summary>
        /// Sorts the first name of the by.
        /// </summary>
        public void SortByFirstName(string filename)
        {
            ReadFile(filename);
            var result = personList.OrderBy(x => x.firstName);
            foreach(var sortPerson in result)
            {
                Console.WriteLine(sortPerson.toString());
            }
        }

        /// <summary>
        /// Sorts the by others.
        /// </summary>
        public void SortByOthers(string filename)
        {
            ReadFile(filename);
            Console.WriteLine("Choose how you want to sort");
            Console.WriteLine("1)SortByCity\n" + "2)SortByState\n" + "3)SortByZip");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    var result = personList.OrderBy(x => x.city);
                    foreach (var sortByCity in result)
                        Console.WriteLine(sortByCity.toString());
                    break;
                case 2:
                    var stateResult = personList.OrderBy(x => x.state);
                    foreach (var sortByState in stateResult)
                        Console.WriteLine(sortByState.toString());
                    break;
                case 3:
                    var zipResult = personList.OrderBy(x => x.zip);
                    foreach (var sortByZip in zipResult)
                        Console.WriteLine(sortByZip.toString());
                    break;
                default:
                    Console.WriteLine("Please enter correct option");
                    break;
            }
        }

        /// <summary>
        /// Reads the file.
        /// </summary>
        /// <param name="filename">The filename.</param>
        public void ReadFile(string filename)
        {
            if (filename.Contains(".csv"))
                personList = readWrite.ReadCsv(filename);
            if (filename.Contains(".txt"))
                personList = readWrite.ReadTxt(filename);
            if (filename.Contains(".json"))
                personList = readWrite.ReadFromJson(filename);
        }

        /// <summary>
        /// Writes the file.
        /// </summary>
        /// <param name="filename">The filename.</param>
        public void WriteFile(string filename,List<Person> personList)
        {
            if (filename.Contains(".csv"))
                readWrite.writeCsv(filename,personList);
            if (filename.Contains(".json"))
                readWrite.WriteJson(filename, personList);
            if (filename.Contains(".txt"))
                readWrite.WriteText(filename, personList);
        }
    }
}
