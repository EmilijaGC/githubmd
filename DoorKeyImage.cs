using UnityEngine;
using UnityEngine.UI;

public class DoorKeyImage : MonoBehaviour
{
    [SerializeField] private GameObject keyImage;  // Your UI image of the key
    [SerializeField] private string playerTag = "Player";

    private void Start()
    {
        if (keyImage != null)
            keyImage.SetActive(false); // Hide at start
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

            // Show image ONLY if player doesn't have the key
            if (playerInventory != null && !playerInventory.hasKey)
            {
                if (keyImage != null)
                    keyImage.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            if (keyImage != null)
                keyImage.SetActive(false);
        }
    }
}
