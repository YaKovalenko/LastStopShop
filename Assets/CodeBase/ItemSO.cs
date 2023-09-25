using UnityEngine;

namespace CodeBase
{
  [CreateAssetMenu(fileName = "New item", menuName = "Item")]
  public class ItemSO : ScriptableObject
  {
    public GameObject sprite;
    public string name;
    public Transform prefab;
  }
}