using Assets.Scripts.CraftingSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingTable : MonoBehaviour
{
    public GameObject CraftingUI;
    public CraftingManager craftingManager;
    private void Start()
    {
        craftingManager = gameObject.GetComponentInChildren<CraftingManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            CraftingUI.SetActive(true);
            craftingManager.Inventory = other.gameObject.GetComponentInChildren<Inventory>();
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            craftingManager.Inventory = null;
            CraftingUI.SetActive(false);
        }
    }
}
