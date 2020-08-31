using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ItemRepository.Interface;
using UnityEngine;

public class Inventory : MonoBehaviour, IItemContainer
{
    [SerializeField] List<Item> startingItems;
    [SerializeField] Transform itemsParent;
    [SerializeField] ItemSlot[] itemSlots;

    private void OnValidate()
    {
        if(itemsParent != null)
        {
            itemSlots = itemsParent.GetComponentsInChildren<ItemSlot>();
        }

        SetStartingItems();
    }
    private void Start()
    {
        SetStartingItems();
    }

    private void SetStartingItems()
    {
        int i = 0;

        for(; i < startingItems.Count && i < itemSlots.Length; i++)
        {
            itemSlots[i].Item = startingItems[i];
            itemSlots[i].Amount = 1;
        }

        for(; i < itemSlots.Length; i++)
        {
            itemSlots[i].Item = null;
            itemSlots[i].Amount = 0;
        }

    }

    public bool AddItem(Item item)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if(itemSlots[i].Item == null || (itemSlots[i].Item.ID == item.ID && itemSlots[i].Amount < item.MaximumStacks))
            {
                itemSlots[i].Item = item;
                itemSlots[i].Amount++;
                return true;
            }
        }

        return false;
    }
    public bool RemoveItem(Item item)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].Item == item)
            {
                itemSlots[i].Amount--;
                if (itemSlots[i].Amount == 0)
                {
                    itemSlots[i].Item = null;
                }
                return true;
            }
        }
        return false;
    }
    public Item RemoveItem(string itemID)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            Item item = itemSlots[i].Item;

            if (item != null && item.ID == itemID)
            {
                itemSlots[i].Amount--;
                if (itemSlots[i].Amount == 0)
                {
                    itemSlots[i].Item = null;
                }
                return item;
            }
        }
        return null;
    }
    public bool IsFull()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].Item == null)
            {
                return false;
            }
        }
        return true;
    }

    public bool ContainsItem(Item item)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i]?.Item == item)
            {
                return true;
            }
        }
        return false;
    }

    public int ItemCount(string itemId)
    {
        var count = 0;

        for (int i = 0; i < itemSlots.Length; i++)
        { 
            if (itemSlots[i]?.Item?.ID == itemId)
            {
                count += itemSlots[i].Amount;
            }
        }
       return count;
    }
}
