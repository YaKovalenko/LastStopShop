using System.Collections.Generic;
using CodeBase.Hero;
using CodeBase.Tables;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase
{
  public class CraftingAnvil : MonoBehaviour
  {
    [SerializeField] private Image recipeImage;
    [SerializeField] private List<CraftingRecipeSO> craftingRecipeSoList;
    [SerializeField] private BoxCollider placeItemsAreaBoxCollider;
    [SerializeField] private Transform itemSpawnPoint;
    [SerializeField] private Transform vfxSpawn;
    [SerializeField] private CraftTable _craftTable;
    [SerializeField] private HeroInventory _heroInventory;

    private CraftingRecipeSO craftingRecipeSo;

    private void Awake()
    {
      NextRecipe();
    }

    public void NextRecipe()
    {
      Debug.Log("Next");
      if (craftingRecipeSo == null)
      {
        craftingRecipeSo = craftingRecipeSoList[0];
      }
      else
      {
        int index = craftingRecipeSoList.IndexOf(craftingRecipeSo);
        index = (index + 1) % craftingRecipeSoList.Count;
        craftingRecipeSo = craftingRecipeSoList[index];
      }

      recipeImage.sprite = craftingRecipeSo.sprite;
    }

    public bool Craft()
    {
      Debug.Log("Craft");
      // Collider[] colliderArray = Physics.OverlapBox(transform.position + placeItemsAreaBoxCollider.center,
      //   placeItemsAreaBoxCollider.size, placeItemsAreaBoxCollider.transform.rotation);
      //
      // List<ItemSO> inputItemList = new List<ItemSO>(craftingRecipeSo.inputItemSOList);
      // List<GameObject> consumeItemGameObjectsList = new List<GameObject>();

      List<int> foundItemFromRecipies = new List<int>();

      foreach (var recipeItem in craftingRecipeSo.inputItemSOList)
      {
        for (int i = 0; i < _craftTable.GetNumberOfSlots(); i++)
        {
          if (recipeItem == _craftTable.GetTableSlot(i).LootItem.ItemSo)
          {
            foundItemFromRecipies.Add(i);
            break;
          }
        }
      }

      if (foundItemFromRecipies.Count == craftingRecipeSo.inputItemSOList.Count)
      {
        Debug.Log("Item will be crafted " + craftingRecipeSo.outputItemSO.name);
      }

      for (int i = 0; i < foundItemFromRecipies.Count; i++)
      {
        _craftTable.ClearTableSlot(foundItemFromRecipies[i]);
      }
      
      var coffin = Instantiate(craftingRecipeSo.outputItemSO.prefab, itemSpawnPoint.position, itemSpawnPoint.rotation, itemSpawnPoint.transform);

      if (_heroInventory.IsCoffinInHand == false)
      {
        _heroInventory.PutCoffinInInventory(coffin);
        return true;
      }

      return false;
      //
      // foreach (Collider collider in colliderArray)
      // {
      //   Debug.Log(collider);
      //   if (collider.TryGetComponent(out Item itemSoHolder))
      //   {
      //     if (inputItemList.Contains(itemSoHolder.ItemSo))
      //     {
      //       inputItemList.Remove(itemSoHolder.ItemSo);
      //       consumeItemGameObjectsList.Add(collider.gameObject);
      //     }
      //   }
      // }

      // if (inputItemList.Count == 0)
      // {
      //   Debug.Log("Yes");
      //   Instantiate(craftingRecipeSo.outputItemSO.prefab, itemSpawnPoint.position, itemSpawnPoint.rotation);
      //   
      //   Instantiate(vfxSpawn, itemSpawnPoint.position, itemSpawnPoint.rotation);
      //
      //   foreach (GameObject consumeItemGameObject in consumeItemGameObjectsList)
      //   {
      //     Destroy(consumeItemGameObject);
      //   }
      // }
      // else
      // {
      //   Debug.Log("No");
      // }
    }
  }
}