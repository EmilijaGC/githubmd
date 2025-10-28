using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    [SerializeField] private GameObject pickupPromptUI; // optional "Press E" text
    private bool playerInRange = false;
    private PlayerInventory playerInventory;

    void Start()
    {
        if (pickupPromptUI != null)
            pickupPromptUI.SetActive(false);
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            PickupKey();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            playerInventory = other.GetComponent<PlayerInventory>();

            if (pickupPromptUI != null)
                pickupPromptUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            playerInventory = null;

            if (pickupPromptUI != null)
                pickupPromptUI.SetActive(false);
        }
    }

    private void PickupKey()
    {
        if (playerInventory != null)
        {
            playerInventory.GiveKey();
        }

        if (pickupPromptUI != null)
            pickupPromptUI.SetActive(false);

        Destroy(gameObject);
    }
}
