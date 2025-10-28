using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] private string mainMenuSceneName = "MainMenu";
    [SerializeField] private GameObject winScreenImage;
    [SerializeField] private float delayBeforeMenu = 3f;

    [Header("UI")]
    [SerializeField] private GameObject needKeyImage; // Assign your "need key" image in Inspector
    [SerializeField] private float keyMessageDuration = 2f;

    private bool hasWon = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasWon) return;

        if (other.CompareTag("Player"))
        {
            PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

            if (playerInventory != null && playerInventory.hasKey)
            {
                hasWon = true;
                StartCoroutine(ShowWinImageAndLoadMenu());
            }
            else
            {
                Debug.Log("🚪 Door locked! You need the key first.");
                if (needKeyImage != null)
                    StartCoroutine(ShowNeedKeyImage());
            }
        }
    }

    private System.Collections.IEnumerator ShowWinImageAndLoadMenu()
    {
        if (winScreenImage != null)
            winScreenImage.SetActive(true);

        yield return new WaitForSeconds(delayBeforeMenu);

        SceneManager.LoadScene(mainMenuSceneName);
    }

    private System.Collections.IEnumerator ShowNeedKeyImage()
    {
        needKeyImage.SetActive(true);
        yield return new WaitForSeconds(keyMessageDuration);
        needKeyImage.SetActive(false);
    }
}
