using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.CraftingSystem
{
    public class CraftingManager : MonoBehaviour
    {
        public Inventory Inventory;
        private Recipe _currentRecipe;
        public bool CraftItem(Recipe recipe)
        {
            _currentRecipe = recipe;

            if(CheckForItems(recipe))
            {
                RemoveIngredients(recipe);
                AddRecipeOutput(recipe);

                return true;
            }

            Debug.Log("You do not have the required components");
            return false;
            
        }
        private void AddRecipeOutput(Recipe recipe)
        {
            Inventory.AddItem(recipe.OutputItem);
        }
        private void RemoveIngredients(Recipe recipe)
        {
            foreach (var ingredient in recipe.ingredients)
            {
                for (int i = 0; i < ingredient.count; i++)
                {
                    Inventory.RemoveItem(ingredient.item);
                }
            }
        }
        public bool CheckForItems(Recipe recipe)
        {
            foreach (var ingredient in recipe.ingredients)
            {
                if (!CheckForIngredient(ingredient))
                {
                    return false;
                }
            }

            return true;
        }
        public bool CheckForIngredient(Ingredient ingredient)
        {
            if(Inventory.ItemCount(ingredient.item.ID) >= ingredient.count)
            {
                return true;
            }

            return false;
        }
    }
}
