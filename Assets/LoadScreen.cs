using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScreen : MonoBehaviour
{
  
    public void PLAY()
    {
        SceneManager.LoadScene("Main");
    }
    public void QUIT()
    {
        Application.Quit();
    }
    public AudioSource audioSource1;
    public AudioSource audioSource2;
    private bool isFirstClick = true;

    public void SoundsButonPlay()
    {
        if(isFirstClick)
        {
            audioSource1.Play();
           
        }
        else
        {
            audioSource2.Play();
            
        }
        isFirstClick = !isFirstClick;
    }
    
}
