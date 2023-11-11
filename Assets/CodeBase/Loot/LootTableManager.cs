using System.Collections.Generic;
using CodeBase.Hero;
using CodeBase.Tables;
using UnityEngine;

namespace CodeBase.Loot
{
  public class LootTableManager : BaseTable
  {
    
    public void TakeOutObject(Item lootItem)
    {
      foreach (TableObject slot in _tableSlots)
      {
        if (slot.LootItem == lootItem)
        {
          if (!_heroInventory.IsItemInHand)
            _heroInventory.PutInInventory(slot.LootItem);

          slot.IsOccupied = false;
          slot.LootItem = null;
          //lootItem.transform.SetParent(HeroPickUpAndDrop.LootParentObject);
          //lootItem.transform.position = PlayerService.LootParentObject.position;

          return;
        }
      }
    }
    
    public void SpawnNewLoot(List<ItemSO> lastLoot)
    {
      foreach (var itemSo in lastLoot)
      {
        PutInObject(CreateWorldItem(itemSo));
      }
    }

    [ContextMenu("TakeObjectFromSlotZero")]
    public void TakeObjectFromSlotZero()
    {
      TakeOutObject(_tableSlots[0].LootItem);
    }

    private Item CreateWorldItem(ItemSO itemSo)
    {
      return Instantiate(itemSo.prefab).Setup(_heroInventory);
    }
  }
}