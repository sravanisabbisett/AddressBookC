using System;

namespace AddressBook
{
    class Program 
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to addressBook ");
            AddressBookimpl addressBook = new AddressBookimpl();
            while (true)
            {
                Console.WriteLine("1)Add Person in AddressBook\n" + "2)Edit Person in Address\n" + "3)Delete Person in AddressBook\n"
                                   +"4)Display addressBook\n"+"5)SearchPerson\n"+"6)CountPersons");
                try
                {
                    var choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            addressBook.AddPerson();
                            break;
                        case 2:
                            addressBook.EditPerson();
                            break;
                        case 3:
                            addressBook.DeletePerson();
                            break;
                        case 4:
                            addressBook.Display();
                            break;
                        case 5:
                            addressBook.SearchPerson();
                            break;
                        case 6:
                            addressBook.CountPerson();
                            break;
                        default:
                            Console.Write("Please Enter correct option");
                            break;
                    }
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
