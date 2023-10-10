using System;
using CodeBase.Infrastructure;
using TMPro;
using UnityEngine;

namespace CodeBase.Hero
{
  public class HeroInteraction : MonoBehaviour
  {
    private HeroInventory _heroInventory;
    [SerializeField] private Camera _characterCamera;
    [SerializeField] private float _interactionDistance;

    [SerializeField] private GameObject _interactionUI;
    [SerializeField] private TextMeshProUGUI _interactionText;

    private void Update()
    {
      //InteractionRay();
      if (Input.GetKeyDown(KeyCode.E))
      {
        
      }
    }

    private void InteractionRay()
    {
      Ray ray = _characterCamera.ViewportPointToRay(Vector3.one / 2f);
      RaycastHit hit;

      bool hitSomething = false;

      if (Physics.Raycast(ray, out hit, _interactionDistance))
      {
        IInteractable interactable = hit.collider.GetComponent<IInteractable>();

        if (interactable != null)
        {
          hitSomething = true;
          _interactionText.text = interactable.GetDescription();

          if (Input.GetKeyDown(KeyCode.E))
          {
            interactable.Interact();
          }
        }
      }
      _interactionUI.SetActive(hitSomething);
    }
  }
}