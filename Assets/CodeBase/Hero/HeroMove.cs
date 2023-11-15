using System.Collections.Generic;
using CodeBase.CameraLogic;
using CodeBase.Infrastructure;
using CodeBase.Services.Input;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace CodeBase.Hero
{
  public class HeroMove : MonoBehaviour
  {
    private Camera _camera;
    private IInputService _inputService;
    private static PointerEventData _eventDataCurrentPosition;
    private static List<RaycastResult> _results;
    [SerializeField] private Animator _animator;

    void Awake()
    {
      _inputService = Game.InputService;
    }

    public NavMeshAgent playerNavMeshAgent;

    public bool isRunning;

    private void Update()
    {
      if (Input.GetMouseButton(0))
      {
        Ray myRay = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit myRaycastHit;

        if (Physics.Raycast(myRay, out myRaycastHit))
        {
          playerNavMeshAgent.SetDestination(myRaycastHit.point);
        }
      }

      if (playerNavMeshAgent.remainingDistance <= playerNavMeshAgent.stoppingDistance)
      {
        _animator.SetFloat("Speed", 0);
        isRunning = false;
      }
      else
      {
        _animator.SetFloat("Speed", 1);
        isRunning = true;
      }
    }

    private void Start()
    {
      _camera = Camera.main;
      CameraFollow();
    }
    
    public static bool IsOverUI()
    {
      _eventDataCurrentPosition = new PointerEventData(EventSystem.current){position = Mouse.current.position.ReadValue()};
      _results = new List<RaycastResult>();
      EventSystem.current.RaycastAll(_eventDataCurrentPosition, _results);
      return _results.Count > 0;
    }

    private void CameraFollow() =>
      _camera.GetComponent<CameraFollow>().Follow(gameObject);
  }
}