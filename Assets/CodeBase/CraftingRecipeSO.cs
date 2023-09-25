using System.Collections.Generic;
using UnityEngine;

namespace CodeBase
{
  [CreateAssetMenu(fileName = "New item", menuName = "CraftingRecipe")]
  public class CraftingRecipeSO : ScriptableObject
  {
    public Sprite sprite;
    public List<ItemSO> inputItemSOList;
    public ItemSO outputItemSO;
  }
}