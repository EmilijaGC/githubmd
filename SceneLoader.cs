using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Loads a scene by build index
    public void LoadSceneByIndex(int sceneIndex)
    {
        Debug.Log("Loading scene with build index: " + sceneIndex);
        SceneManager.LoadScene(sceneIndex);
    }

    // Quits the game (for Exit button)
    public void QuitGame()
    {
        Debug.Log("Exiting game...");
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // stops play mode in editor
#endif
    }
}
