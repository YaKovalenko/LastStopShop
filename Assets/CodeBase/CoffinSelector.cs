using System;
using System.Collections.Generic;
using CodeBase.Hero;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CodeBase
{
  public class CoffinSelector : MonoBehaviour
  {
    [SerializeField] private List<ItemSO> _coffins;
    [SerializeField] private ItemSO _selectedCoffin;
    [SerializeField] private HeroInventory _heroInventory;

    private void Start()
    {
      RollSelectedCoffin();
    }

    private void OnTriggerStay(Collider other)
    {
      if (other.CompareTag("Player"))
      {
        if (Input.GetKey(KeyCode.E))
        {
          if (_heroInventory.IsCoffinInHand && _heroInventory.RemoveCoffinFromInventory().ItemSo == _selectedCoffin)
          {
            Debug.Log("Coffins the same");
            _heroInventory.RemoveCoffinFromInventory();
          }
          else
          {
            Debug.Log("Bad coffin");
          }
        }
      }
    }

    public void RollSelectedCoffin()
    {
      _selectedCoffin = _coffins[Random.Range(0, _coffins.Count)];
    }

  }
}