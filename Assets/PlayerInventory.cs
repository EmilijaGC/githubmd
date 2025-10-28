using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    // Public so other scripts can check
    public bool hasKey = false;

    // Call this when the player picks up the key
    public void GiveKey()
    {
        hasKey = true;
        Debug.Log("🔑 Key added to inventory!");
    }
}
