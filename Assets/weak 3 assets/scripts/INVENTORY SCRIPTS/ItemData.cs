using UnityEngine;

public enum ItemType
{
    Battery,
    CopperWire,
    EMPCore,
    EMPGrenade,
    SignalJammer,
    Medkit
}

[CreateAssetMenu(fileName = "NewItemData", menuName = "Survival System/Item Data")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public ItemType itemType;
    public Sprite icon;
    public int maxStackSize = 99;
    public string description;
}