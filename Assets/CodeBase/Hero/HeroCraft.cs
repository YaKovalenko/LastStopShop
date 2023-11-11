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
        Debug.Log("Inside crafting table");
        if (Input.GetKeyDown(KeyCode.N))
        {
          _craftingAnvil.NextRecipe();
        }
        if (Input.GetKey(KeyCode.E))
        {
          _craftTable.TakeItemFromPlayer();
        }
        if (Input.GetKeyUp(KeyCode.C) && _freezeInput == false)
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