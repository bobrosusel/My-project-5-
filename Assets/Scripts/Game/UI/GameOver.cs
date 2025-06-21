using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private float _activeMenuDelay;

    private void Awake()
    {
        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        Debug.Log("PENIS");
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
    }
}
