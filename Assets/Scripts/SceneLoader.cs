using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    int GameMenuSceneIndex = 0;
    int GameStartSceneIndex = 1;
    int GameOverSceneIndex = 2;
    public void SceneLoad(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void GameMenu()
    {
        SceneManager.LoadScene(GameMenuSceneIndex);
    }
    public void GameStart()
    {
        SceneManager.LoadScene(GameStartSceneIndex);
    }

    public void GameOver()
    {
        SceneManager.LoadScene(GameOverSceneIndex);
    }
    public void GameQuit()
    {
        Application.Quit();
    }


}
