using ItemRepository.Interface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour, IInteractable
{
    [SerializeField] Item item;
    [SerializeField] Inventory inventory;

    public bool InRange;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            inventory = other.gameObject.GetComponentInChildren<Inventory>();
            InRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        inventory = null;
        InRange = false;
    }

    public void Interact(GameObject interactingObject)
    {
        Debug.Log("Called Interact on Item Pickup Object");
        if (InRange)
        {
          var pickedUp = inventory.AddItem(item);

            if(pickedUp)
            {
                Destroy(gameObject);
            }
        };
    }
}
