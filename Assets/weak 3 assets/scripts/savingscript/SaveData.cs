using System;
using System.Collections.Generic;

[Serializable]
public class InventoryItemSaveData
{
    public string itemName;
    public int amount;
}

[Serializable]
public class SaveData
{
    public float positionX;
    public float positionY;
    public float positionZ;
    public float currentHealth;
    public List<InventoryItemSaveData> inventoryItems = new List<InventoryItemSaveData>();
}