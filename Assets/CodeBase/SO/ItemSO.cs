using UnityEngine;

namespace CodeBase
{
  [CreateAssetMenu(fileName = "New item", menuName = "Item")]
  public class ItemSO : ScriptableObject
  {
    public string name;
    public Item prefab;
  }
}