using System;

namespace AddressBook
{
    class Program 
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to addressBook ");
            AddressBookimpl addressBook = new AddressBookimpl();
            ReadWrite readWrite = new ReadWrite();
            while (true)
            {
                Console.WriteLine("**Printing list of files**\n");
                readWrite.ShowFiles();
                Console.WriteLine("Enter your filename in which u want to perform operation");
                string filename = Console.ReadLine();
                Console.WriteLine("\n");
                Console.WriteLine("1)Add Person in AddressBook\n" + "2)Edit Person in Address\n" + "3)Delete Person in AddressBook\n"
                                   +"4)Display addressBook\n"+"5)SearchPerson\n"+"6)CountPersons\n"+"7)View person\n"
                                    +"8)sortByFirstName\n"+"9)SortByOthers");
                try
                {
                    var choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            addressBook.AddPerson(filename);
                            break;
                        case 2:
                            addressBook.EditPerson(filename);
                            break;
                        case 3:
                            addressBook.DeletePerson(filename);
                            break;
                        case 4:
                            addressBook.Display(filename);
                            break;
                        case 5:
                            addressBook.SearchPerson(filename);
                            break;
                        case 6:
                            addressBook.CountPerson(filename);
                            break;
                        case 7:
                            addressBook.ViewAddressBook();
                            break;
                        case 8:
                            addressBook.SortByFirstName(filename);
                            break;
                        case 9:
                            addressBook.SortByOthers(filename);
                            break;
                        default:
                            Console.WriteLine("Please Enter correct option");
                            break;
                    }
                    Console.WriteLine("\n");
                    Console.WriteLine("Do you want to continue(Y / N) ? ");
                    var variable = Console.ReadLine();
                    if (variable.Equals("y"))
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                catch(System.FormatException formatException)
                {
                    Console.WriteLine(formatException);
                }
                catch(AddressBookException Exception)
                {
                    Console.WriteLine(Exception.Message);
                }
            }
            Console.ReadKey();
        }
    }
}
