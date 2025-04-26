using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private string _gameSceneName = "Game";
    public void StartGame()
    {
        SceneManager.LoadScene(_gameSceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
