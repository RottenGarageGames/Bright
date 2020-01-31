using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class CraftingMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject CraftableItemSlotsPrefab;
    public GameObject GridLayout;
    public Double TimeBetweenInstantiations;
    public int MaxCraftingSlots;
    public RecipeDatabase recipeDatabase;

   async void Start()
    {
        foreach (var recipe in recipeDatabase.Recipes)
        {
            if (recipe != null)
            {
                var slot = Instantiate(CraftableItemSlotsPrefab);
                slot.transform.parent = GridLayout.transform;
                var craftingSlot = slot.GetComponent<CraftingSlot>();
                craftingSlot.recipe = recipe;
                craftingSlot.SetData();
                craftingSlot.SetIngredients();
                await Task.Delay(TimeSpan.FromSeconds(TimeBetweenInstantiations));
            }
        }

    }


}
