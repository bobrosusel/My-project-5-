using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private string _menu = "Menu";
    public event Action Back;

    public void Quit()
    {
        Back?.Invoke();
        SceneManager.LoadScene(_menu);
    }

    public void BackToGame()
    {
        Back?.Invoke();
    }
}
