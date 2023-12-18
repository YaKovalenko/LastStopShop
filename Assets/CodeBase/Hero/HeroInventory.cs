using UnityEngine;

namespace CodeBase.Hero
{
  public class HeroInventory : MonoBehaviour
  {
    [SerializeField] private Item _itemInHand;
    [SerializeField] private Transform _handPosition;
    [SerializeField] private Item _coffinInHand;
    [SerializeField] private Transform _coffinPosition;
    public bool IsItemInHand { get; private set; }
    public bool IsCoffinInHand { get; private set; }
    
    public void PutCoffinInInventory(Item itemToPut)
    {
      _coffinInHand = itemToPut;
      IsCoffinInHand = true;
      _coffinInHand.transform.parent = _coffinPosition;
      _coffinInHand.transform.localPosition = Vector3.zero;
    }

    public Item RemoveCoffinFromInventory()
    {
      var currentCoffin = _coffinInHand;
      _coffinInHand = null;
      IsCoffinInHand = false;
      return currentCoffin;
    }
    
    public void PutInInventory(Item itemToPut)
    {
      if (IsItemInHand == false)
      {
        _itemInHand = itemToPut;
        IsItemInHand = true;
        _itemInHand.transform.parent = _handPosition;
        _itemInHand.transform.localPosition = Vector3.zero;
      }
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