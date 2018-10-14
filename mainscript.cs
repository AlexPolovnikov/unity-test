using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainscript : MonoBehaviour {
    public void Play()
    {
        SceneManager.LoadScene("Game");
    }
    public void ReStart()
    {
        SceneManager.LoadScene("Game");
    }
    public void ToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
