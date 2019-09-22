using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    [SerializeField]
    private string sceneName;

    public void GoToScene()
    {
        string s = PlayerPrefs.GetString("currentLevel");
        if(s != null && s != "")
        {
            SceneManager.LoadScene(PlayerPrefs.GetString("currentLevel"));
        }
        else
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    public void QuitApp()
    {
        Application.Quit();
    }

    public void GoBackToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
