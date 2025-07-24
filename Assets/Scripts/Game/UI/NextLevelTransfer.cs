using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelTransfer : MonoBehaviour
{
    private AudioSource _audioSource;

    private void OnEnable()
    {
        _audioSource = GetComponent<AudioSource>();
        StartCoroutine(TransferDelay());
    }

    private void TransferToNextLevel()
    {
        int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextIndex >= 0 && nextIndex < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(nextIndex);
        else
            SceneManager.LoadScene(0);
    }


    private IEnumerator TransferDelay()
    {
        yield return new WaitForSeconds(_audioSource.clip.length);
        TransferToNextLevel();
    }
}
