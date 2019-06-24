using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public float delay;

    public void LoadStartMenuScene()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadGameOverScene()
    {
        StartCoroutine(WaitBeforeGameOver());
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadFirstLevel()
    {
        FindObjectOfType<GameManager>().ResetGame();
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private IEnumerator WaitBeforeGameOver()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("GameOver");
    }
}
