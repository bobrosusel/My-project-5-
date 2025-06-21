using UnityEngine;

public class StateManager : MonoBehaviour
{
    [SerializeField] private GameObject _pause;
    [SerializeField] private GameObject _gameOver;

    [SerializeField] private Shoot _shoot;
    [SerializeField] private PlayerHealth _playerHealth;

    private PauseMenu _pauseMenu;
    private bool _isPaused;

    private void Awake()
    {
        _pauseMenu = _pause.GetComponent<PauseMenu>();
    }

    private void OnEnable()
    {
        _pauseMenu.Back += TogglePause;
        _shoot.BulletOver += GameOver;
        _playerHealth.PlayerDeath += GameOver;
    }

    private void OnDisable()
    {
        _pauseMenu.Back -= TogglePause;
        _shoot.BulletOver -= GameOver;  
        _playerHealth.PlayerDeath -= GameOver;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    private void GameOver()
    {
        _gameOver.SetActive(_gameOver);
    }

    private void TogglePause()
    {
        _isPaused = !_isPaused;
        
        _pause.SetActive(_isPaused);
        Time.timeScale = _isPaused ? 0f : 1f;
        AudioListener.pause = _isPaused; 
    }
}
