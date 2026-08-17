using UnityEngine;

public class CraftingHandler : MonoBehaviour
{
    public InventoryHandler inventory;

    public bool CanCraft(CraftingRecipe recipe)
    {
        if (recipe == null || inventory == null) return false;

        foreach (var ingredient in recipe.ingredients)
        {
            if (!inventory.HasItem(ingredient.item, ingredient.amount))
            {
                return false;
            }
        }
        return true;
    }

    public bool CraftItem(CraftingRecipe recipe)
    {
        if (!CanCraft(recipe)) return false;

        foreach (var ingredient in recipe.ingredients)
        {
            inventory.RemoveItem(ingredient.item, ingredient.amount);
        }

        inventory.AddItem(recipe.resultItem, recipe.resultAmount);
        return true;
    }
}