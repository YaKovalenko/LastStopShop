using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CodeBase.MiniGame
{
  public class MiniGame : MonoBehaviour, IPointerClickHandler
  {
    [SerializeField] private GameObject _canvas;

    public void OnPointerClick(PointerEventData eventData)
    {
      Debug.Log("Click");
      _canvas.SetActive(true);

    }
  }
}