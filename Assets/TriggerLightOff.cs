using UnityEngine;
using UnityEngine.UI;   // Needed for UI

public class TriggerLightOff : MonoBehaviour
{
    [Header("References")]
    public Light targetLight;        // The light to turn off
    public Text warningText;         // UI Text element that says "RUN!"
    public string message = "RUN!";  // Message to display

    private void Start()
    {
        // Make sure the text is hidden at the start
        if (warningText != null)
        {
            warningText.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player enters the trigger zone
        if (other.CompareTag("Player"))
        {
            // Turn off the light
            if (targetLight != null)
                targetLight.enabled = false;

            // Show the message
            if (warningText != null)
            {
                warningText.text = message;
                warningText.gameObject.SetActive(true);
            }
        }
    }
}
