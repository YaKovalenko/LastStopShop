using CodeBase.CameraLogic;
using CodeBase.Infrastructure;
using CodeBase.Services.Input;
using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.Hero
{
  public class HeroMove : MonoBehaviour
  {
    private Camera _camera;
    private IInputService _inputService;

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
        isRunning = false;
      }
      else
      {
        isRunning = true;
      }
    }

    private void Start()
    {
      _camera = Camera.main;
      CameraFollow();
    }

    private void CameraFollow() =>
      _camera.GetComponent<CameraFollow>().Follow(gameObject);
  }
}