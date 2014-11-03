using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace FindPerson
{
    class PhoneBook
    {
        MultiDictionary<string, PhoneRecord> names;
        MultiDictionary<string, PhoneRecord> towns;
        MultiDictionary<string, PhoneRecord> phones;

        public PhoneBook(List<PhoneRecord> phoneRecords)
        {
            names = new MultiDictionary<string, PhoneRecord>(true);
            towns = new MultiDictionary<string, PhoneRecord>(true);
            phones = new MultiDictionary<string, PhoneRecord>(true);

            FillLists(phoneRecords);
        }

        public List<PhoneRecord> Find(string name)
        {
            List<PhoneRecord> list = new List<PhoneRecord>();
            foreach (var item in names)
            {
                if (item.Key.Contains(name))
                {
                    list.AddRange(item.Value);
                }
            }

            return list;
        }

        public List<PhoneRecord> Find(string name, string town)
        {
            List<PhoneRecord> list = new List<PhoneRecord>();
            foreach (var item in names)
            {
                if (item.Key.Contains(name))
                {
                    foreach (var record in item.Value)
                    {
                        if (record.Town == town)
                        {
                            list.Add(record);
                        }
                    }
                }
            }

            return list;
        }

        private void FillLists(List<PhoneRecord> phoneRecords)
        {
            foreach (var record in phoneRecords)
            {
                names.Add(record.Name, record);
                towns.Add(record.Town, record);
                phones.Add(record.Phone, record);
            }
        }
    }
}
