using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [Header("Interaction Settings")]
    public float interactRange = 3.5f;
    public LayerMask interactableLayer = ~0; // ~0 means Everything layer

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E key pressed!");
            TryInteract();
        }
    }

    private void TryInteract()
    {
        // Player ke paas 3.5 meter range mein saare colliders find karta hai
        Collider[] colliders = Physics.OverlapSphere(transform.position, interactRange, interactableLayer);
        
        bool foundInteractable = false;

        foreach (var col in colliders)
        {
            // Direct component check
            IInteractable interactable = col.GetComponent<IInteractable>();

            // Agar main object par na mile to parent par check
            if (interactable == null)
            {
                interactable = col.GetComponentInParent<IInteractable>();
            }

            if (interactable != null)
            {
                foundInteractable = true;
                Debug.Log("Interacting with: " + col.gameObject.name);
                interactable.Interact();
                break; // Ek waqt mein ek object se interact karega
            }
        }

        if (!foundInteractable)
        {
            Debug.LogWarning("No IInteractable object found nearby within range of " + interactRange + "m!");
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Scene view mein red wireframe sphere dikhayega interaction range ka
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, interactRange);
    }
}