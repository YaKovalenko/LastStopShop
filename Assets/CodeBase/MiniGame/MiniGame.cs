using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CodeBase.MiniGame
{
  public class MiniGame : MonoBehaviour, IPointerClickHandler
  {
    [SerializeField] private GameObject _canvas;

    private void Awake()
    {
      EventManager.MiniGameEnded += CloseMiniGameWindow;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
      Debug.Log("Click");
      _canvas.SetActive(true);

    }

    private void CloseMiniGameWindow()
    {
      _canvas.SetActive(false);
    }
  }
}