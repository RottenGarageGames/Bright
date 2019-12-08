using System.Collections.Generic;

namespace ItemRepository.Interface
{
    public interface IItemRepository
    {
        IEnumerable<Item> GetItems();
        Item GetItem(string ItemID);
        void AddItem(Item newItem);
        void UpdateItem(int ItemID, Item updatedItem);
        void DeleteItem(int itemID);
        void UpdateItems(IEnumerable<Item> updatedItems);
    }
}
