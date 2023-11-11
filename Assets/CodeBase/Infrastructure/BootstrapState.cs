using CodeBase.Services.Input;
using UnityEngine;

namespace CodeBase.Infrastructure
{
  public class BootstrapState : IState
  {
    private const string Initial = "Initial";
    private readonly GameStateMachine _stateMachine;
    private readonly SceneLoader _sceneLoader;

    public bool IsUpdatable { get; }

    public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, bool isUpdatable = false)
    {
      _stateMachine = stateMachine;
      _sceneLoader = sceneLoader;
      IsUpdatable = isUpdatable;
    }

    public void Enter()
    {
      //RegisterServices();
      _sceneLoader.Load(Initial, onLoaded: EnterLoadLevel);
    }

    private void EnterLoadLevel() =>
      _stateMachine.Enter<LoadLevelState, string>("Main");

    public void Exit()
    {
    }

    public void Update()
    {
    }

    public void RegisterServices()
    {
      Game.InputService = RegisterInputService();
    }

    private static IInputService RegisterInputService()
    {
      if (Application.isEditor)
        return new StandaloneInputService();
      else
        return new MobileInputService();
    }
  }
}