using System;
using CodeBase.Hero;
using UnityEngine;

namespace CodeBase
{
  public class Item : MonoBehaviour
  {
    public ItemSO ItemSo;
    [SerializeField] private HeroInventory _heroInventory;

    public Item Setup(HeroInventory heroInventory)
    {
      _heroInventory = heroInventory;
      return this;
    }

    private void OnMouseDown()
    {
      _heroInventory.PutInInventory(this);
      Debug.Log("Item was clicked");
    }
  }
}