using System;

[Serializable]
public class InventorySlot
{
    public ItemData item;
    public int quantity;

    public InventorySlot(ItemData newItem, int initialQuantity)
    {
        item = newItem;
        quantity = initialQuantity;
    }
}