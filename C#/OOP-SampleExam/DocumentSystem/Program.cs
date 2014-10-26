namespace DocumentSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public interface IEncryptable
    {
        bool IsEncrypted { get; }
        void Encrypt();
        void Decrypt();
    }

    public interface IDocument
    {
        string Name { get; }
        string Content { get; }
        void LoadProperty(string key, string value);
        void SaveAllProperties(IList<KeyValuePair<string, object>> output);
        string ToString();
    }

    public interface IEditable
    {
        void ChangeContent(string newContent);
    }

    class Program
    {
        public static List<IDocument> documents = new List<IDocument>();
        static void Main()
        {
            IList<string> allCommands = ReadAllCommands();
            ExecuteCommands(allCommands);
        }

        private static IList<string> ReadAllCommands()
        {
            List<string> commands = new List<string>();
            while (true)
            {
                string commandLine = Console.ReadLine();
                if (commandLine == string.Empty)
                {
                    // End of commands
                    break;
                }
                commands.Add(commandLine);
            }
            return commands;
        }

        private static void ExecuteCommands(IList<string> commands)
        {
            foreach (var commandLine in commands)
            {
                int paramsStartIndex = commandLine.IndexOf("[");
                string cmd = commandLine.Substring(0, paramsStartIndex);
                int paramsEndIndex = commandLine.IndexOf("]");
                string parameters = commandLine.Substring(
                    paramsStartIndex + 1, paramsEndIndex - paramsStartIndex - 1);
                ExecuteCommand(cmd, parameters);
            }
        }

        private static void ExecuteCommand(string cmd, string parameters)
        {
            string[] cmdAttributes = parameters.Split(
                new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            if (cmd == "AddTextDocument")
            {
                AddTextDocument(cmdAttributes);
            }
            else if (cmd == "AddPDFDocument")
            {
                AddPdfDocument(cmdAttributes);
            }
            else if (cmd == "AddWordDocument")
            {
                AddWordDocument(cmdAttributes);
            }
            else if (cmd == "AddExcelDocument")
            {
                AddExcelDocument(cmdAttributes);
            }
            else if (cmd == "AddAudioDocument")
            {
                AddAudioDocument(cmdAttributes);
            }
            else if (cmd == "AddVideoDocument")
            {
                AddVideoDocument(cmdAttributes);
            }
            else if (cmd == "ListDocuments")
            {
                ListDocuments();
            }
            else if (cmd == "EncryptDocument")
            {
                EncryptDocument(parameters);
            }
            else if (cmd == "DecryptDocument")
            {
                DecryptDocument(parameters);
            }
            else if (cmd == "EncryptAllDocuments")
            {
                EncryptAllDocuments();
            }
            else if (cmd == "ChangeContent")
            {
                ChangeContent(cmdAttributes[0], cmdAttributes[1]);
            }
            else
            {
                throw new InvalidOperationException("Invalid command: " + cmd);
            }
        }

        private static void AddTextDocument(string[] attributes)
        {
            TextDocument document = new TextDocument();

            AddDocument(attributes, document);
        }

        private static void AddDocument(string[] attributes, IDocument document)
        {
            foreach (var attribute in attributes)
            {
                string[] tokens = attribute.Split('=');
                string currentKey = tokens[0];
                string currentValue = tokens[1];

                document.LoadProperty(currentKey, currentValue);
            }

            if (document.Name != null)
            {
                documents.Add(document);
                Console.WriteLine("Document added: " + document.Name);
            }
            else
            {
                Console.WriteLine("Document has no name");
            }
        }

        private static void AddPdfDocument(string[] attributes)
        {
            PDFDocument document = new PDFDocument();

            AddDocument(attributes, document);
        }

        private static void AddWordDocument(string[] attributes)
        {
            WordDocument document = new WordDocument();

            AddDocument(attributes, document);
        }

        private static void AddExcelDocument(string[] attributes)
        {
            ExcelDocument document = new ExcelDocument();

            AddDocument(attributes, document);
        }

        private static void AddAudioDocument(string[] attributes)
        {
            AudioDocument document = new AudioDocument();

            AddDocument(attributes, document);
        }

        private static void AddVideoDocument(string[] attributes)
        {
            VideoDocument document = new VideoDocument();

            AddDocument(attributes, document);
        }

        private static void ListDocuments()
        {
            if (documents.Count == 0)
            {
                Console.WriteLine("No documents found");
            }
            else
            {
                foreach (var document in documents)
                {
                    Console.WriteLine(document);
                }
            }
        }

        private static void EncryptDocument(string name)
        {
            bool isFound = false;
            foreach (var document in documents)
            {
                if (document.Name == name)
                {
                    isFound = true;
                    if (document is EncryptableDocument)
                    {
                        (document as EncryptableDocument).Encrypt();
                        Console.WriteLine("Document encrypted: " + document.Name); 
                    }
                    else
                    {
                        Console.WriteLine("Document does not support encryption: " + document.Name);
                    }
                }
            }

            if (!isFound)
            {
                Console.WriteLine("Document not found: " + name);
            }
        }

        private static void DecryptDocument(string name)
        {
            bool isFound = false;
            foreach (var document in documents)
            {
                if (document.Name == name)
                {
                    isFound = true;
                    if (document is EncryptableDocument)
                    {
                        (document as EncryptableDocument).Decrypt();
                        Console.WriteLine("Document decrypted: " + document.Name);
                    }
                    else
                    {
                        Console.WriteLine("Document does not support decryption: " + document.Name);
                    }
                }
            }

            if (!isFound)
            {
                Console.WriteLine("Document not found: " + name);
            }
        }

        private static void EncryptAllDocuments()
        {
            bool isFound = false;
            foreach (var document in documents)
            {
                if (document is IEncryptable)
                {
                    isFound = true;
                    (document as IEncryptable).Encrypt();
                }                
            }

            if (isFound)
            {
                Console.WriteLine("All documents encrypted");
            }
            else
            {
                Console.WriteLine("No encryptable documents found");
            }
        }

        private static void ChangeContent(string name, string content)
        {
            bool isFound = false;
            foreach (var document in documents)
            {
                if (document.Name == name)
                {
                    isFound = true;
                    if (document is IEditable)
                    {
                        (document as IEditable).ChangeContent(content);
                        Console.WriteLine("Document content changed: " + document.Name);
                    }
                    else
                    {
                        Console.WriteLine("Document is not editable: " + document.Name);
                    }
                }
            }

            if (!isFound)
            {
                Console.WriteLine("Document not found: " + name);
            }
        }
    }
}
