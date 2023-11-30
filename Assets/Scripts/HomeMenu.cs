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
}
