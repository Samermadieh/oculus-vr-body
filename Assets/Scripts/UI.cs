using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    
    public void playBtn()
    {
        SceneManager.LoadScene("Main");
    }

    public void quitBtn()
    {
        Application.Quit();
    }

}
