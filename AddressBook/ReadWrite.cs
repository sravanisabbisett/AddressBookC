using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AddressBook
{
    class ReadWrite
    {
        /// <summary>
        /// Writes the text.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="addressbook">The addressbook.</param>
        public void WriteText(string filename,List<Person> addressbook)
        {
            string path = "C:\\Users\\PC\\source\\repos\\AddressBook\\AddressBook\\" + filename;
            StreamWriter writer = new StreamWriter(path);
            string[] line1 = { "Firstname", "Lastname", "address", "city", "state", "zip", "mobilenumber" };
            string line11=string.Join(",", line1);
            writer.WriteLine(line11);
            for (int a = 0; a < addressbook.Count; a++)
            {
                Person index = addressbook[a];
                string[] line2 = { index.firstName, index.lastName, index.city, index.state, index.zip,index.mobileNumber };
                string line22=string.Join(",", line2);
                writer.WriteLine(line22);

            }
            writer.Flush();
            writer.Close();
        }

        public void WriteCity(string filename, List<Person> addressbook)
        {
            string path = "C:\\Users\\PC\\source\\repos\\AddressBook\\AddressBook\\" + filename;
            StreamWriter writer = new StreamWriter(path);
            string[] line1 = { "Firstname", "city", "state"};
            string line11 = string.Join(",", line1);
            writer.WriteLine(line11);
            for (int a = 0; a < addressbook.Count; a++)
            {
                Person index = addressbook[a];
                Console.WriteLine(index.firstName);
                string[] line2 = { index.firstName, index.city, index.state };
                string line22 = string.Join(",", line2);
                writer.WriteLine(line22);

            }
            writer.Flush();
            writer.Close();
        }
        /// <summary>
        /// Reads the text.
        /// </summary>
        /// <param name="Filename">The filename.</param>
        /// <returns></returns>
        public List<Person> ReadTxt(string Filename) 
        {
            string path= "\\Users\\PC\\source\\repos\\AddressBook\\AddressBook\\" + Filename;
            StreamReader BR=new StreamReader(path);
            List<Person> person = new List<Person>();
            string line = null;
            int i = 0;
            while ((line=BR.ReadLine())!=null)
            {
                i=i+1;
                if (i!=1)
                {
                    string[] value = line.Split(",");
                    person.Add(new Person(value[0], value[1], value[2], value[3], value[4], value[5]));
                }
            }
            BR.Close();
            return person;
        }

        public List<Person> ReadCityTxt(string Filename)
        {
            string path = "\\Users\\PC\\source\\repos\\AddressBook\\AddressBook\\" + Filename;
            StreamReader BR = new StreamReader(path);
            List<Person> person = new List<Person>();
            string line = null;
            int i = 0;
            while ((line = BR.ReadLine()) != null)
            {
                i = i + 1;
                if (i != 1)
                {
                    string[] value = line.Split(",");
                    person.Add(new Person(value[0], value[1], value[2]));
                }
            }
            BR.Close();
            return person;
        }

        /// <summary>
        /// Shows the files.
        /// </summary>
        public void ShowFiles()
        {
            string path = "\\Users\\PC\\source\\repos\\AddressBook\\AddressBook\\";
            string[] fileArray = Directory.GetFiles(path, "*.txt");
            foreach (string file in fileArray)
            {
                Console.WriteLine(file);
            }
            
        }

    }
}
