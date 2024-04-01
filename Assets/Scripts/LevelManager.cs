using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    [SerializeField] float sceneLoadDelay = 2f;
    public void loadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void loadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void loadGameOver()
    {
        StartCoroutine(waitAndLoad("Game Over", sceneLoadDelay));
    }

    public void QuitGame()
    {
        Debug.Log("Iesi ma!");
        Application.Quit();
    }


    IEnumerator waitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
