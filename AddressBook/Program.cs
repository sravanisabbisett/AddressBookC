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
                Console.WriteLine("1)Add Person in AddressBook\n" + "2)Edit Person in Address\n" + "3)Delete Person in AddressBook");
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
                   //throw new AddressBookException(formatException.Message);
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
