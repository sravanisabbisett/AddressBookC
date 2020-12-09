using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook
{
    interface IAddressBook
    {
        void AddPerson(string filename);
        void EditPerson(string filename);
        void DeletePerson(string filename);
    }
}
