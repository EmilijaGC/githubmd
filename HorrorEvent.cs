using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class HorrorEvent : MonoBehaviour
{
    public GameObject jumpscareObject; // The jumpscare prefab or object
    public Text messageText; // UI Text for showing "Find the key"
    public float timerDuration = 120f; // 2 minutes in seconds
    public GameObject keyObject; // Key the player needs to pick up

    private bool eventTriggered = false;
    private bool keyFound = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !eventTriggered)
        {
            eventTriggered = true;
            StartCoroutine(HandleHorrorEvent());
        }
    }

    IEnumerator HandleHorrorEvent()
    {
        // 1. Trigger the jumpscare
        jumpscareObject.SetActive(true);
        yield return new WaitForSeconds(1.5f); // adjust to your jumpscare length
        jumpscareObject.SetActive(false);

        // 2. Show "Find the key" message
        messageText.text = "Find the key";

        // 3. Start the countdown timer
        float remainingTime = timerDuration;
        while (remainingTime > 0 && !keyFound)
        {
            remainingTime -= Time.deltaTime;
            messageText.text = $"Find the key\nTime left: {Mathf.Ceil(remainingTime)}s";
            yield return null;
        }

        if (!keyFound)
        {
            // 4. Timer finished and key not found, reset scene
            SceneManager.LoadScene(0);
        }
        else
        {
            // Key found, clear message
            messageText.text = "You found the key!";
        }
    }

    // Call this method when the player picks up the key
    public void KeyPickedUp()
    {
        keyFound = true;
        keyObject.SetActive(false); // Hide or destroy key
    }
}
