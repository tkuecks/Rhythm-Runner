using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {
 
public void Controls()
    {
        SceneManager.LoadScene(1);
    }
public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

public void PlayGame()
    {
        Destroy(GameObject.Find("Score"));
        Destroy(GameObject.Find("Meter"));
        SceneManager.LoadScene(3);
    }

public void GameOver()
    {
        SceneManager.LoadScene(2);
    }

public void LevelTransition()
    {
        SceneManager.LoadScene(4);
    }
public void Level2(){
    SceneManager.LoadScene(5);
}

public void VictoryScreen()
    {
        SceneManager.LoadScene(6);
    }
public void Credits()
    {
        SceneManager.LoadScene(7);
    }
public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
}
