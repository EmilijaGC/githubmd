using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public string requiredKeyID = "MainDoorKey";
    public Animator doorAnimator; // optional if using animation

    private bool isOpen = false;

    private void OnTriggerEnter(Collider other)
    {
        if (isOpen) return;

        if (other.CompareTag("Player"))
        {
            PlayerInventory inventory = other.GetComponent<PlayerInventory>();
            if(inventory != null && inventory.hasKey)

            {
                OpenDoor();
            }
            else
            {
                Debug.Log("Door locked. You need the key.");
            }
        }
    }

    private void OpenDoor()
    {
        isOpen = true;

        if (doorAnimator)
        {
            doorAnimator.SetTrigger("Open");
        }
        else
        {
            // If no animator, just disable the door (simple open)
            gameObject.SetActive(false);
        }

        Debug.Log("Door opened!");
    }
}
