using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ItemRepository.Interface;
using UnityEngine;

public class Inventory : IItemContainer
{
    public List<Item> items;
    public int MaxItems;

    public event Action<Item> OnItemInteract;
    public bool AddItem(Item item)
    {
        if(!IsFull())
        {
            items.Add(item);
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool ContainsItem(Item item)
    {
        if (items.Where(x => x.ID == item.ID).FirstOrDefault() != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool IsFull()
    {
        if (items.Count() >= MaxItems)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public int ItemCount(Item item)
    {
        return items.Where(x => x.ID == item.ID).Count(); 
    }

    public bool RemoveItem(Item item)
    {
        if(ContainsItem(item))
        {
            items.Remove(item);
            return true;
        }
        else
        {
            return false;
        }
    }
}
