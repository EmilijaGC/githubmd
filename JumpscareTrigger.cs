using UnityEngine;

public class JumpscareTrigger : MonoBehaviour
{
    [Header("Jumpscare Settings")]
    public GameObject jumpscareObject;      // The monster or image to show
    public AudioSource jumpscareSound;      // Audio source for the scream
    public float scareDuration = 2f;        // How long the jumpscare lasts

    public bool hasTriggered = false;

    void Start()
    {
        // Make sure jumpscare object is hidden at the start
        if (jumpscareObject != null)
            jumpscareObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if player entered the trigger
        if (other.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;
            StartCoroutine(DoJumpscare());
        }
    }

    private System.Collections.IEnumerator DoJumpscare()
    {
        // Show the jumpscare object
        if (jumpscareObject != null)
            jumpscareObject.SetActive(true);

        // Play scream sound
        if (jumpscareSound != null)
            jumpscareSound.Play();

        // Optional: Camera shake
        

        // Wait
        yield return new WaitForSeconds(scareDuration);

        // Hide the jumpscare object
        if (jumpscareObject != null)
            jumpscareObject.SetActive(false);

        // Destroy the trigger so it doesn’t trigger again
        Destroy(gameObject);
    }
}
