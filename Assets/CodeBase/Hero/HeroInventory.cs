using UnityEngine;

namespace CodeBase.Hero
{
  public class HeroInventory : MonoBehaviour
  {
    [SerializeField] private Item _itemInHand;
    [SerializeField] private Transform _handPosition;

    public bool IsItemInHand { get; private set; }

    public void PutInInventory(Item itemToPut)
    {
      _itemInHand = itemToPut;
      IsItemInHand = true;
    }

    public Item RemoveFromInventory()
    {
      var currentItem = _itemInHand;
      
      _itemInHand = null;
      IsItemInHand = false;
      return currentItem;
    }
  }
}