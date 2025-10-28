using UnityEngine;
using TMPro;  // ✅ Import TextMeshPro

public class TriggerAllLightsOff : MonoBehaviour
{
    [Header("Lights")]
    public Light[] lightsToTurnOff;

    [Header("UI")]
    public TextMeshProUGUI warningText;   // 👈 TMP text
    public string message = "RUN!";

    private void Start()
    {
        if (warningText != null)
            warningText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Turn off all lights if none are assigned
            if (lightsToTurnOff != null && lightsToTurnOff.Length > 0)
            {
                foreach (Light l in lightsToTurnOff)
                    if (l != null) l.enabled = false;
            }
            else
            {
                Light[] allLights = FindObjectsOfType<Light>();
                foreach (Light l in allLights)
                    l.enabled = false;
            }

            // Show the warning text
            if (warningText != null)
            {
                warningText.text = message;
                warningText.gameObject.SetActive(true);
            }
        }
    }
}
