using UnityEngine;

public class TeleportDoor : MonoBehaviour, IInteractable
{
    [Header("Teleport Settings")]
    public Transform destinationDoor;
    public Vector3 spawnOffset = new Vector3(0, 0, 1.5f);

    public string GetInteractPrompt()
    {
        return "Press E to Enter Door";
    }

    public void Interact()
    {
        if (destinationDoor == null)
        {
            Debug.LogWarning("Destination Door assign nahi hai Inspector mein!");
            return;
        }

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            CharacterController cc = player.GetComponent<CharacterController>();

            if (cc != null) cc.enabled = false;

            player.transform.position = destinationDoor.position + destinationDoor.TransformDirection(spawnOffset);
            player.transform.rotation = destinationDoor.rotation;

            if (cc != null) cc.enabled = true;

            Debug.Log("Teleported to: " + destinationDoor.name);
        }
    }
}