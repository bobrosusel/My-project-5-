using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _arrow;
    [SerializeField] private GameObject _escapeButton;


    public event Action Back;
    

    private void OnEnable()
    {
        OffOutSideUI(false);
    }

    private void OnDisable()
    {
        OffOutSideUI(true);
    }

    private void OffOutSideUI(bool active)
    {
        _arrow.SetActive(active);
        _escapeButton.SetActive(active);    
    }

    public void Quit()
    {
        Back?.Invoke();
        SceneManager.LoadScene(0);
    }

    public void BackToGame()
    {
        Back?.Invoke();
    }
}
