using UnityEngine;

public class PooledItemPickup : MonoBehaviour
{
    public ItemData itemData;
    public int amount = 1;
    public string poolKey; // "FuelCanister" ya "FoodPack"

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InventoryHandler inventory = other.GetComponent<InventoryHandler>();
            if (inventory != null && itemData != null)
            {
                inventory.AddItem(itemData, amount);
                
                // Destroy ki jagah object pool mein return
                if (ObjectPoolManager.Instance != null && !string.IsNullOrEmpty(poolKey))
                {
                    ObjectPoolManager.Instance.ReturnToPool(poolKey, gameObject);
                }
                else
                {
                    gameObject.SetActive(false);
                }
            }
        }
    }
}