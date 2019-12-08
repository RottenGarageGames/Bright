using Assets.Repositories.ItemRepo;
using ItemRepository.CSV;
using ItemRepository.Interface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadItem : MonoBehaviour
{

    private IItemRepository itemRepository;
    public string ID;
    public string Name;

    // Start is called before the first frame update
    void Start()
    {
        itemRepository = new JsonItemRepository();
        LoadBaseData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadBaseData()
    {
        var item = itemRepository.GetItem(ID);
        Name = item.Name;
        gameObject.name = Name;
    }
}
