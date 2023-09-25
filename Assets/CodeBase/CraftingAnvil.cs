using System.Collections.Generic;
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

    public void Craft()
    {
      Debug.Log("Craft");
      Collider[] colliderArray = Physics.OverlapBox(transform.position + placeItemsAreaBoxCollider.center,
        placeItemsAreaBoxCollider.size, placeItemsAreaBoxCollider.transform.rotation);

      List<ItemSO> inputItemList = new List<ItemSO>(craftingRecipeSo.inputItemSOList);
      List<GameObject> consumeItemGameObjectsList = new List<GameObject>();

      foreach (Collider collider in colliderArray)
      {
        Debug.Log(collider);
        if (collider.TryGetComponent(out ItemSoHolder itemSoHolder))
        {
          if (inputItemList.Contains(itemSoHolder.ItemSo))
          {
            inputItemList.Remove(itemSoHolder.ItemSo);
            consumeItemGameObjectsList.Add(collider.gameObject);
          }
        }
      }

      if (inputItemList.Count == 0)
      {
        Debug.Log("Yes");
        Instantiate(craftingRecipeSo.outputItemSO.prefab, itemSpawnPoint.position, itemSpawnPoint.rotation);
        
        Instantiate(vfxSpawn, itemSpawnPoint.position, itemSpawnPoint.rotation);

        foreach (GameObject consumeItemGameObject in consumeItemGameObjectsList)
        {
          Destroy(consumeItemGameObject);
        }
      }
      else
      {
        Debug.Log("No");
      }
    }
  }
}