using System;
using CodeBase.Tables;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Hero
{
  public class HeroCraft : MonoBehaviour
  {
    [SerializeField] private CraftingAnvil _craftingAnvil;
    [SerializeField] private CraftTable _craftTable;
    private bool _freezeInput;

    private void OnTriggerStay(Collider other)
    {
      if (other.CompareTag("CraftingTable"))
      {
        if (Input.GetKey(KeyCode.N))
        {
          _craftingAnvil.NextRecipe();
        }
        if (Input.GetKey(KeyCode.E))
        {
          _craftTable.TakeItemFromPlayer();
        }
        if (Input.GetKey(KeyCode.C) && _freezeInput == false)
        {
          if (_craftingAnvil.Craft())
          {
            _freezeInput = true;
          }
        }
      }
    }
  }
}