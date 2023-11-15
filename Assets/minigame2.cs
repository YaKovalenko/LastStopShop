using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minigame2 : MonoBehaviour
{   
    public GameObject PanelMiniGame;
    
    private bool isPaused = false;
    private void Start()
    {
        // Ensure the pause panel is initially hidden
        PanelMiniGame.SetActive(false);
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
             {
                ResumeGame();
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
    private void ResumeGame()
    {
        PanelMiniGame.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    private void PauseGame()
    {
        PanelMiniGame.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
}
