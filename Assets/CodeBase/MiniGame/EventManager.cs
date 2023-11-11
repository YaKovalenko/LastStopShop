using System;
using UnityEngine;

namespace CodeBase.MiniGame
{
  public class EventManager : MonoBehaviour
  {
    public static event Action MiniGameEnded;

    public static void OnMiniGameEnded()
    {
      MiniGameEnded?.Invoke();
    }
  }
}