using ItemRepository.Interface;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class Ingredient : ScriptableObject
{
    public Item item;
    public int count;

}