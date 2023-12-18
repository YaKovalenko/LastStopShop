using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  public void Exit()
  {
    SceneManager.LoadScene("main menu");
  }

  public GameObject PausePanel;


  private bool isPaused = false;

  private void Start()
  {
    // Ensure the pause panel is initially hidden
    PausePanel.SetActive(false);
  }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Escape))
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