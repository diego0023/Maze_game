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

    public void setSpeed(int speed)
    {
        
        switch (speed)
        {
            case 0:
                Player.speed = 5;
                break;
            case 1:
                Player.speed = 10;
                break;
            case 2:
                Player.speed = 15;
                break;
            default:
                Player.speed = 15;
                break;
        }
        Debug.Log(Player.speed);
    } 
}
