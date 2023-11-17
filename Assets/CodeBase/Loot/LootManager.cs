using System;
using System.Collections.Generic;
using CodeBase.MiniGame;
using UnityEngine;

namespace CodeBase.Loot
{
  public class LootManager : MonoBehaviour
  {
    [SerializeField] private List<ItemSO> _lastLoot;
    [SerializeField] private LootTableManager _lootTableManager;
    private ItemSO _newLoot;

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
  }
}