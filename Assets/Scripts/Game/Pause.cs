using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject _pause;
    [SerializeField] private GameObject _panel;

    private PauseMenu _pauseMenu;
    private bool _isPaused;

    private void Awake()
    {
        _pauseMenu = _panel.GetComponent<PauseMenu>();
    }

    private void OnEnable()
    {
        _pauseMenu.Back += TogglePause;
    }

    private void OnDisable()
    {
        _pauseMenu.Back -= TogglePause;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    private void TogglePause()
    {
        _isPaused = !_isPaused;
        
        _pause.SetActive(_isPaused);
        Time.timeScale = _isPaused ? 0f : 1f;
        AudioListener.pause = _isPaused; 
    }
}
