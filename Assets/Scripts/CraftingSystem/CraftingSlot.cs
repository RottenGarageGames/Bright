using Assets.Scripts.CraftingSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingSlot : MonoBehaviour
{
    public Recipe recipe;
    public Text ItemName;
    public Image Image;
    public GameObject IngredientGroup;
    public GameObject IngredientTextField;

    void Start()
    {
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(CraftItem);
    }
    void CraftItem()
    {
        Debug.Log("You have clicked the button!");
        gameObject.GetComponentInParent<CraftingManager>().CraftItem(recipe);
    }

    public void SetData()
    {
        Image.sprite = recipe.OutputItem.Icon;
        ItemName.text = recipe.OutputItem.name;
    }
    public void SetIngredients()
    {
        foreach (var ingredient in recipe.ingredients)
        {
            Debug.Log(ingredient.name + " " + ingredient.count);
            var ingredientTextField = Instantiate(IngredientTextField, IngredientGroup.transform);
            IngredientTextField.GetComponent<Text>().text = ingredient.name;
        }
    }
}
