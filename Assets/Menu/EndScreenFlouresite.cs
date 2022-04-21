using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndScreenFlouresite : MonoBehaviour
{
    public void Restart () {
        SceneManager.LoadScene("StartScreen");

    }

    public void QuitGame() {
        Application.Quit();
    }
}
