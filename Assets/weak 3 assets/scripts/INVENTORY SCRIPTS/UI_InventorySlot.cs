using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_InventorySlot : MonoBehaviour
{
    public Image iconImage;
    public TextMeshProUGUI quantityText;

    public void UpdateSlot(Sprite icon, int quantity)
    {
        if (icon != null)
        {
            iconImage.sprite = icon;
            iconImage.enabled = true;
            quantityText.text = quantity > 1 ? quantity.ToString() : "";
        }
        else
        {
            ClearSlot();
        }
    }

    public void ClearSlot()
    {
        iconImage.sprite = null;
        iconImage.enabled = false;
        quantityText.text = "";
    }
}