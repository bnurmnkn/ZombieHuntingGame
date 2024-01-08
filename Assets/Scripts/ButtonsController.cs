using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeMenu : MonoBehaviour
{

    int level;
    public void PlayButton()
    {
        
        SceneManager.LoadScene(1);
        Time.timeScale=1f;
        

    } 
  
    public void ExitButton()
    {
        Debug.Log("We left the game!");
        Application.Quit();

    }  
    public void CountinueButton()
    {
       
       
        level=PlayerPrefs.GetInt("Level",1);
        Debug.Log(level);
        SceneManager.LoadScene(level);

    }




    public void HomePages()
    {
        SceneManager.LoadScene(0);
        Time.timeScale=1f;
    }
    public void GameAgainButton()
    {
       int Index=SceneManager.GetActiveScene().buildIndex;
       SceneManager.LoadScene(Index);
       Time.timeScale=1f;

    }
     public void GameCountinueButton()
    {
        level=SceneManager.GetActiveScene().buildIndex;
       
        level++;
        PlayerPrefs.SetInt("Level",level);
        PlayerPrefs.Save();

        SceneManager.LoadScene(level);
        Time.timeScale=1f;
    }
  
}
