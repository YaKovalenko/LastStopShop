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
        if (Input.GetKeyDown(KeyCode.N))
        {
          _craftingAnvil.NextRecipe();
        }
        if (Input.GetKeyDown(KeyCode.E))
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

    // private void Update()
    // {
    //   if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, interactDistance))
    //   {
    //     if (raycastHit.transform.TryGetComponent(out CraftingAnvil craftingAnvil))
    //     {
    //       if (Input.GetKeyDown(KeyCode.C))
    //       {
    //         craftingAnvil.NextRecipe();
    //       }
    //
    //       if (Input.GetMouseButtonDown(0))
    //       {
    //         craftingAnvil.Craft();
    //       }
    //     }
    //   }
    //}
  }
}