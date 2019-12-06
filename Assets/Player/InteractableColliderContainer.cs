using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableColliderContainer : ColliderContainer
{
    public List<GameObject> GetInteractableItems()
    {
        var items = new List<GameObject>();

        foreach (var item in GetColliders())
        {
            if (item != null)
            {
                if (item.GetComponent<IInteractable>() != null)
                {
                    items.Add(item.gameObject);
                }
            }
        }

        return items;
    }
}
