﻿using System;

namespace AddressBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to addressBook ");
            AddressBookimpl addressBook = new AddressBookimpl();
            addressBook.AddUser();
            Console.ReadKey();
           
            
        }
    }
}
