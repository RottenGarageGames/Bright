using ItemRepository.Interface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTaker : MonoBehaviour
{
    public Item ItemToTake;
    public int AmountToTake;


    public bool TakeItems(IItemContainer itemContainer)
    {
       if(itemContainer.ContainsItem(ItemToTake) && itemContainer.ItemCount(ItemToTake.ID) >= AmountToTake)
        {
            for (int i = 0; i < AmountToTake; i++)
            {
                itemContainer.RemoveItem(ItemToTake);
            }

            return true;
        }

        return false;
    }
}
