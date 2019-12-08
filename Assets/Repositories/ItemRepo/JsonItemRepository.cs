using ItemRepository.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Assets.Repositories.ItemRepo
{
    class JsonItemRepository : IItemRepository
    {
        string path;

        public JsonItemRepository()
        {
            path = "Assets/Resources/Items.json";
        }

        public IEnumerable<Item> GetItems()
        {
            List<Item> items = JsonConvert.DeserializeObject<List<Item>>(File.ReadAllText(path));
            return items;
        }

        public Item GetItem(string ID)
        {
            var items = GetItems();
            var item = items.FirstOrDefault(x => x.ID == ID);
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

