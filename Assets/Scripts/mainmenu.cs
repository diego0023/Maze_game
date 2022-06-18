using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
   public void exitButton()
    {
        Application.Quit();
        Debug.Log("Saliendo");
    }

    public void starGame()
    {
        SceneManager.LoadScene("game");
    }
}
