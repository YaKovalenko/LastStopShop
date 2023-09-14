using UnityEngine;

namespace CodeBase.Services.Input
{
  public class InputService : IInputService
  {
    protected const string Horizontal = "Horizontal";
    protected const string Vertical = "Vertical";
    
    public Vector2 Axis
    {
      get
      {
        Vector2 axis = UnityAxis();
        return axis;
      }
    }

    private static Vector2 UnityAxis() => 
      new(UnityEngine.Input.GetAxis(Horizontal), UnityEngine.Input.GetAxis(Vertical));
  }
}