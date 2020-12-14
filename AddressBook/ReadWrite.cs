using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
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

        /// <summary>
        /// Shows the files.
        /// </summary>
        public void ShowFiles()
        {
            string path = "\\Users\\PC\\source\\repos\\AddressBook\\AddressBook\\";
            string[] fileArray = Directory.GetFiles(path, "*.txt");
            string[] fileArrays = Directory.GetFiles(path, "*.csv");
            string[] fileArraysjson = Directory.GetFiles(path, "*.json");
            foreach (string file in fileArray)
                Console.WriteLine(Path.GetFileName(file));
            foreach(string file in fileArrays)
                Console.WriteLine(Path.GetFileName(file));
            foreach (string file in fileArraysjson)
                Console.WriteLine(Path.GetFileName(file));
        }

        /// <summary>
        /// Writes the dictionary to text.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="dictionary">The dictionary.</param>
        public void WriteDictionaryToTxt(string filename,Dictionary<string,string> dictionary)
        {
            string path = "\\Users\\PC\\source\\repos\\AddressBook\\AddressBook\\" + filename;
            using (StreamWriter file = new StreamWriter(path))
                foreach (var entry in dictionary)
                    file.WriteLine("{0},{1}", entry.Key, entry.Value);
        }

        /// <summary>
        /// Reads from text to dictionary.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns></returns>
        public Dictionary<string,string> ReadFromTxtToDictionary(string filename)
        {
            string path = "\\Users\\PC\\source\\repos\\AddressBook\\AddressBook\\" + filename;
            //Dictionary<string, string> dictionary = new Dictionary<string, string>();
            var dictionary = File.ReadLines(path).Select(line => line.Split(',')).
                            ToDictionary(split => split[0], split => split[1]);
            return dictionary;
        }

        /// <summary>
        /// Writes the CSV.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="list">The list.</param>
        public void writeCsv(string filename,List<Person> list)
        {
            string path = "\\Users\\PC\\source\\repos\\AddressBook\\AddressBook\\" + filename;
            using (var writer = new StreamWriter(path))
            using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csvWriter.Configuration.Delimiter = ",";
                csvWriter.Configuration.HasHeaderRecord = true;
                csvWriter.Configuration.AutoMap<Person>();
                csvWriter.WriteHeader<Person>();
                csvWriter.NextRecord();
                csvWriter.WriteRecords(list);
                writer.Flush();
                writer.Close();
            }
            
        }

        /// <summary>
        /// Reads the CSV.
        /// </summary>
        /// <param name="Filename">The filename.</param>
        /// <returns></returns>
        public List<Person> ReadCsv(string filename)
        {
            string path = "\\Users\\PC\\source\\repos\\AddressBook\\AddressBook\\" + filename;
            StreamReader BR = new StreamReader(path);
            CsvReader csvReader = new CsvReader(BR,CultureInfo.InvariantCulture);
            List<Person> person = new List<Person>();
            person = csvReader.GetRecords<Person>().ToList();
            BR.Close();
            return person;
        }

        /// <summary>
        /// Writes the json.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="person">The person.</param>
        public void WriteJson(string filename,List<Person> person)
        {
            string path = "\\Users\\PC\\source\\repos\\AddressBook\\AddressBook\\" + filename;
            string json = JsonConvert.SerializeObject(person.ToArray());
            File.WriteAllText(path, json);
        }

        /// <summary>
        /// Reads from json.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns></returns>
        public List<Person> ReadFromJson(string filename)
        {
            string path = "\\Users\\PC\\source\\repos\\AddressBook\\AddressBook\\" + filename;
            string jsonFile = File.ReadAllText(path);
            List<Person> person = JsonConvert.DeserializeObject<List<Person>>(jsonFile);
            return person;
        }
    }
}
