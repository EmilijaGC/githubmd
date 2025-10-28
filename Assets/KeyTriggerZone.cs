using UnityEngine;
using TMPro;

public class ShowTextOnTrigger : MonoBehaviour
{
    public TextMeshProUGUI textToShow;  // Assign in Inspector
    public string playerTag = "Player"; // Tag your player as "Player"

    void Start()
    {
        if (textToShow != null)
            textToShow.gameObject.SetActive(false); // Hide on start
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            if (textToShow != null)
                textToShow.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            if (textToShow != null)
                textToShow.gameObject.SetActive(false);
        }
    }
}
