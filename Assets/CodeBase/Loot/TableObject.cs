using System;
using UnityEngine;

namespace CodeBase.Loot
{
  [Serializable]
  public class TableObject
  {
    public Transform SlotPosition;
    public Item LootItem;
    public bool IsOccupied;
  }
}