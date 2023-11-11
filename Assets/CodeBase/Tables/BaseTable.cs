using CodeBase.Hero;
using CodeBase.Loot;
using UnityEngine;

namespace CodeBase.Tables
{
  public class BaseTable : MonoBehaviour
  {
    [SerializeField] protected TableObject[] _tableSlots;
    [SerializeField] protected HeroInventory _heroInventory;

    public void PutInObject(Item lootItem)
    {
      foreach (var slotToSet in _tableSlots)
      {
        if (slotToSet.IsOccupied == false)
        {
          slotToSet.IsOccupied = true;
          slotToSet.LootItem = lootItem;
          lootItem.transform.SetParent(slotToSet.SlotPosition);
          lootItem.transform.position = slotToSet.SlotPosition.position;
          //PlayerService.CurrentItemInHand = null;
          //PlayerService.HandIsFull = false;
          return;
        }
      }
    }

    public int GetNumberOfSlots()
    {
      return _tableSlots.Length;
    }

    public TableObject GetTableSlot(int slotIndex)
    {
      return _tableSlots[slotIndex];
    }

    public void ClearTableSlot(int slotIndex)
    {
      Destroy(_tableSlots[slotIndex].LootItem.gameObject);
      _tableSlots[slotIndex].LootItem = null;
      _tableSlots[slotIndex].IsOccupied = false;
    }
  }
}