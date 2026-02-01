using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string playSceneName = "Island1";

    public void PlayGame()
    {
        SceneManager.LoadScene(playSceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit (only works in build).");
    }
}