using UnityEngine;

namespace CodeBase.Tables
{
  public class CraftTable : BaseTable
  {
    [ContextMenu("MoveItemFromPlayerToTable")]
    public void TakeItemFromPlayer()
    {
      if (_heroInventory.IsItemInHand)
      {
        PutInObject(_heroInventory.RemoveFromInventory());
      }
    }
  }
}