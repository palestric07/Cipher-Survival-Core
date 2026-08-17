using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ResourceIngredient
{
    public ItemData item;
    public int amount = 1;
}

[CreateAssetMenu(fileName = "NewCraftingRecipe", menuName = "Survival System/Crafting Recipe")]
public class CraftingRecipe : ScriptableObject
{
    public string recipeName;
    public ItemData resultItem;
    public int resultAmount = 1;
    public List<ResourceIngredient> ingredients = new List<ResourceIngredient>();
}