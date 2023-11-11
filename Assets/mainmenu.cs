using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    // public RectTransform m_parent;
    // public Camera m_uiCamera;
    // public RectTransform m_image;

    
       public void Exit()
       {
         SceneManager.LoadScene("main menu");
       }
    // public void Menua()  // for some reasons it doesnt work
    // {
    //     if(Input.GetMouseButtonDown(0))
    //     {
    //         Vector2 anchoredPose;
    //         RectTransformUtility.ScreenPointToLocalPointInRectangle(m_parent, Input.mousePosition, m_uiCamera, out anchoredPose);
            
    //         Rect PlayButton = new Rect(-150, 150, -200, 200); //problems 
    //         if (PlayButton.Contains(anchoredPose))
    //         {
    //             ResumeGame();
    //         }
            
    //         Rect QuitButton = new Rect(-150, 150, -100, 100); //pro b l e m s 
    //         if (QuitButton.Contains(anchoredPose))
    //         {
    //             SceneManager.LoadScene("Main");
    //         }

            
    //     }
        
    // }  

    public GameObject PausePanel;
    
    
    private bool isPaused = false;
    private void Start()
    {
        // Ensure the pause panel is initially hidden
        PausePanel.SetActive(false);
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
             {
                ResumeGame();
             }
            else
            {
                PauseGame();
            }
        }
        
    }
    public void Pause()
    {
        PauseGame();
    }
    public void Resume()
    {
        ResumeGame();
    }


     private void PauseGame()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    private void ResumeGame()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
}
