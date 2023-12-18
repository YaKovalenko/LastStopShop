using System;
using System.Collections.Generic;
using CodeBase.Hero;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CodeBase
{
  public class CoffinSelector : MonoBehaviour
  {
    [SerializeField] private List<ItemSO> _coffins;
    [SerializeField] private ItemSO _selectedCoffin;
    [SerializeField] private HeroInventory _heroInventory;
    
    public static event Action PlayerWon;
    public static event Action PlayerLose;

    private void Start()
    {
      RollSelectedCoffin();
    }

    private void OnTriggerStay(Collider other)
    {
      if (other.CompareTag("Player") == false)
      {
        return;
      }

      if (Input.GetKey(KeyCode.E) == false)
      {
        return;
      }

      if (_heroInventory.IsCoffinInHand == false)
      {
        return;
      }

      var coffin = _heroInventory.RemoveCoffinFromInventory();

      if (coffin.ItemSo == _selectedCoffin)
      {
        Debug.Log("Coffins the same");
        OnPlayerWon();

        Destroy(coffin.gameObject);
      }
      else
      {
        Debug.Log("Bad coffin");
        OnPlayerLose();
        Destroy(coffin.gameObject);
      }
    }
    
    public static void OnPlayerWon()
    {
      PlayerWon?.Invoke();
    }
    
    public static void OnPlayerLose()
    {
      PlayerLose?.Invoke();
    }

    public void RollSelectedCoffin()
    {
      _selectedCoffin = _coffins[Random.Range(0, _coffins.Count)];
    }
  }
}