using System;
using System.Collections.Generic;
using System.IO;

namespace FindPerson
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileRecords = ReadPhoneRecordsFromFile("phones.txt");
            var commands = ReadCommandsFromFile("commands.txt");

            PhoneBook book = new PhoneBook(fileRecords);
            ExecuteCommands(book, commands);
        }

        private static List<PhoneRecord> ReadPhoneRecordsFromFile(string file)
        {
            List<PhoneRecord> records = new List<PhoneRecord>();
            StreamReader reader = new StreamReader(file);
            string line = reader.ReadLine();
            while (line != null)
            {
                string[] tokens = line.Split('|');
                string name = tokens[0].Trim();
                string town = tokens[1].Trim();
                string phone = tokens[2].Trim();
                records.Add(new PhoneRecord(name, town, phone));

                line = reader.ReadLine();
            }

            return records;
        }

        private static List<Command> ReadCommandsFromFile(string file)
        {
            List<Command> commands = new List<Command>();
            StreamReader reader = new StreamReader(file);
            string line = reader.ReadLine();
            while (line != null)
            {
                string name = line.Substring(0, line.IndexOf('('));
                if (line.IndexOf(',') == -1)
                {
                    int start = line.IndexOf('(') + 2;
                    int length = line.IndexOf(')') - (start + 1);
                    string parameter = line.Substring(start, length);

                    commands.Add(new Command(name, parameter));
                }
                else
                {
                    string paramString = line.Substring(line.IndexOf('('));
                    string[] parameters = paramString.Split(new char[] { ',', '(', ')', '"', ';', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    
                    commands.Add(new Command(name, parameters));
                }

                line = reader.ReadLine();
            }

            return commands;
        }

        private static void ExecuteCommands(PhoneBook book, List<Command> commands)
        {
            foreach (var command in commands)
            {
                if (command.Name == "find")
                {
                    List<PhoneRecord> records;
                    if (command.Parameters.Length == 1)
                    {
                        records = book.Find(command.Parameters[0]);
                    }
                    else
                    {
                        records = book.Find(command.Parameters[0], command.Parameters[1]);
                    }

                    PrintPhoneRecordsOnConsole(records);
                }
            }
        }

        private static void PrintPhoneRecordsOnConsole(List<PhoneRecord> records)
        {
            foreach (var record in records)
            {
                Console.WriteLine(record);
            }
        }
    }
}
