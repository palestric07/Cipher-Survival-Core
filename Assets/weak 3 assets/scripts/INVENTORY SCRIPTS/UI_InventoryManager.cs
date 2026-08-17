using System.Collections.Generic;
using UnityEngine;

public class UI_InventoryManager : MonoBehaviour
{
    public InventoryHandler playerInventory;
    public Transform slotContainer;
    public GameObject slotPrefab;

    private List<UI_InventorySlot> uiSlots = new List<UI_InventorySlot>();

    private void Start()
    {
        if (playerInventory != null)
        {
            playerInventory.OnInventoryChanged += RefreshUI;
            InitializeSlots();
            RefreshUI();
        }
    }

    private void OnDestroy()
    {
        if (playerInventory != null)
        {
            playerInventory.OnInventoryChanged -= RefreshUI;
        }
    }

    private void InitializeSlots()
    {
        foreach (Transform child in slotContainer)
        {
            Destroy(child.gameObject);
        }
        uiSlots.Clear();

        for (int i = 0; i < playerInventory.maxSlots; i++)
        {
            GameObject newSlot = Instantiate(slotPrefab, slotContainer);
            UI_InventorySlot slotScript = newSlot.GetComponent<UI_InventorySlot>();
            uiSlots.Add(slotScript);
        }
    }

    public void RefreshUI()
    {
        for (int i = 0; i < uiSlots.Count; i++)
        {
            if (i < playerInventory.slots.Count)
            {
                var slotData = playerInventory.slots[i];
                uiSlots[i].UpdateSlot(slotData.item.icon, slotData.quantity);
            }
            else
            {
                uiSlots[i].ClearSlot();
            }
        }
    }
}