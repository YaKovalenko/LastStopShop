using System;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Loot
{
  public class LootManager : MonoBehaviour
  {
    [SerializeField] private List<ItemSO> _lastLoot;
    [SerializeField] private LootTableManager _lootTableManager;
    
    //For debug only
    [SerializeField] private ItemSO _debugItem;

    public void AddLoot(List<ItemSO> newLoot)
    {
      
    }
    
    
    public void AddLoot(ItemSO newLoot)
    {
      if (_lastLoot == null)
      {
        _lastLoot = new List<ItemSO>();
      }
      
      _lastLoot.Add(newLoot);

      _lootTableManager.SpawnNewLoot(_lastLoot);
    }

    [ContextMenu("AddItem")]
    public void DebugAddLoot()
    {
      AddLoot(_debugItem);
    }
  }
}