using UnityEngine;

public class ChestInteract : MonoBehaviour, IInteractable
{
    [Header("Chest Parts")]
    public Transform chestLid; // Chest ka upper lid part
    public float openAngle = -80f; // Lid khulne ka angle
    
    private bool isOpen = false;

    public string GetInteractPrompt() => isOpen ? "Press E to Close Chest" : "Press E to Open Chest";

    public void Interact()
    {
        isOpen = !isOpen;

        // Agar open ho raha hai to negative angle, band ho raha hai to positive angle
        float angleToRotate = isOpen ? openAngle : -openAngle;

        if (chestLid != null)
        {
            chestLid.Rotate(angleToRotate, 0, 0, Space.Self);
        }
        else
        {
            transform.Rotate(angleToRotate, 0, 0, Space.Self);
        }

        Debug.Log(isOpen ? "Chest Opened!" : "Chest Closed!");
    }
}