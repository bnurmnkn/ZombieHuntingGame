using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeMenu : MonoBehaviour
{
    public void PlayButton()
    {
        int nextIndex=SceneManager.GetActiveScene().buildIndex+1;
        SceneManager.LoadScene(nextIndex);

    } 
  
    public void ExitButton()
    {
        Debug.Log("We left the game!");
        Application.Quit();

    }  
    public void HomePages()
    {
        SceneManager.LoadScene(0);
    }
    public void GameAgainButton()
    {
       int Index=SceneManager.GetActiveScene().buildIndex;
       SceneManager.LoadScene(Index);

    }
     public void GameCountinueButton()
    {
        int nextIndex=SceneManager.GetActiveScene().buildIndex+1;
        SceneManager.LoadScene(nextIndex);

    }
  
}
