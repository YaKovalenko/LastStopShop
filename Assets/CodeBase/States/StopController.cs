using System;
using UnityEngine;

namespace CodeBase.States
{
  public class StopController : MonoBehaviour
  {
    [SerializeField] private GameObject _miniGameCanvas;
    private void Update()
    {
      
      if (_miniGameCanvas.activeInHierarchy)
      {
        GameState currentGameState = GameStateManager.Instance.CurrentGameState;
        GameState newGameState = currentGameState == GameState.Gameplay
          ? GameState.Paused
          : GameState.Gameplay;
      
        GameStateManager.Instance.SetState(newGameState);
      }
    }
  }
}