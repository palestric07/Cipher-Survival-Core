using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public ItemData itemData;
    public int amount = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InventoryHandler inventory = other.GetComponent<InventoryHandler>();
            if (inventory != null)
            {
                bool added = inventory.AddItem(itemData, amount);
                if (added)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}