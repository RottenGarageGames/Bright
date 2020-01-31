using ItemRepository.Interface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class Recipe : ScriptableObject
{
    public List<Ingredient> ingredients;
    public Item OutputItem;
}