using UnityEngine;
using UnityEngine.SceneManagement;


public class StateMananger : MonoBehaviour
{
    [SerializeField] private GameObject _pause;
    [SerializeField] private GameObject _gameOver;
    [SerializeField] private GameObject _gameWin;

    [SerializeField] private Shoot _shoot;
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private EnemyCountChecker _enemyChecker;

    private PauseMenu _pauseMenu;
    private bool _isPaused;
    private bool _onState = false;

    private void Awake()
    {
        _pauseMenu = _pause.GetComponent<PauseMenu>();
    }

    private void OnEnable()
    {
        InputCheker.Input.Escape += TogglePause;
        _pauseMenu.Back += TogglePause;
        _shoot.BulletOver += GameOver;
        _playerHealth.PlayerDeath += GameOver;
        _enemyChecker.EnemyDone += Win;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        InputCheker.Input.Escape -= TogglePause;
        _pauseMenu.Back -= TogglePause;
        _shoot.BulletOver -= GameOver;
        _playerHealth.PlayerDeath -= GameOver;
        _enemyChecker.EnemyDone -= Win;
    }

    private void GameOver()
    {
        if (_enemyChecker.GetChildrenCount() != 0 && !_onState)
            _gameOver.SetActive(true);
        
    }

    private void Win()
    {
        if (!_onState)
            _gameWin.SetActive(true);
    }

    private void TogglePause()
    {
        if (!_onState)
        {
            _isPaused = !_isPaused;
            _pause.SetActive(_isPaused);
            Time.timeScale = _isPaused ? 0f : 1f;
            AudioListener.pause = _isPaused;
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        InputCheker.Input.RestartTouchScreen();
    }

}
