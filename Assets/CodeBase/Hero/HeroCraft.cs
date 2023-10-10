using UnityEngine;

namespace CodeBase.Hero
{
  public class HeroCraft : MonoBehaviour
  {
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private LayerMask interactLayerMask;
    [SerializeField] private float interactDistance;

    private void Update()
    {
      if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, interactDistance))
      {
        if (raycastHit.transform.TryGetComponent(out CraftingAnvil craftingAnvil))
        {
          if (Input.GetKeyDown(KeyCode.C))
          {
            craftingAnvil.NextRecipe();
          }

          if (Input.GetMouseButtonDown(0))
          {
            craftingAnvil.Craft();
          }
        }
      }
    }
  }
}