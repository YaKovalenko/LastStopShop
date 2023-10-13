using UnityEngine;

namespace CodeBase.Loot
{
  public class MiniGameLootItem : MonoBehaviour
  {
    [SerializeField] private ItemSO _itemSo;

    public ItemSO GetItemData()
    {
      if(_itemSo != null)
        return _itemSo;
      else
      {
        Debug.LogError("Item isn't set for this MiniGameLootItem.");
        return null;
      }

    }
  }
}