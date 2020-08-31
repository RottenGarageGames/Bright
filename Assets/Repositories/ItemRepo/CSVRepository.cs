using System;
using System.Collections.Generic;
using System.IO;
using ItemRepository.Interface;
using System.Configuration;
using System.Diagnostics;

namespace ItemRepository.CSV
{
    public class CSVRepository : IItemRepository
    {
        string path;

        public CSVRepository()
        {  
            path = "Assets/Resources/Items.txt";
        }

        public IEnumerable<Item> GetItems()
        {
            var items = new List<Item>();

            if (File.Exists(path))
            {
                using (var sr = new StreamReader(path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var elems = line.Split(',');
                        var item = new Item()
                        {
                            Name = elems[1],
                        };
                        items.Add(item);
                    }
                }
            }

            return items;
        }

        public Item GetItem(string ID)
        {
            
            Item item = new Item();
            if (File.Exists(path))
            {
                var sr = new StreamReader(path);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var elems = line.Split(',');

                    var parsedId = elems[0];

                    if (parsedId == ID)
                    {
                        item.Name = elems[1];
                    }
                }
            }

            return item;
        }

        public void AddItem(Item item)
        {
            throw new NotImplementedException();
        }

        public void UpdateItem(int id, Item updatedItem)
        {
            throw new NotImplementedException();
        }

        public void DeleteItem(int ID)
        {
            throw new NotImplementedException();
        }

        public void UpdateItems(IEnumerable<Item> updatedItems)
        {
            throw new NotImplementedException();
        }
    }
}
