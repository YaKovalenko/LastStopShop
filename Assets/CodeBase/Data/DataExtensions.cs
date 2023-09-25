using UnityEngine;

namespace CodeBase.Data
{
  public static class DataExtensions
  {
    public static Vector3 AsUnityVector(this Vector3Data vector3Data) =>
      new Vector3(vector3Data.X, vector3Data.Y, vector3Data.Z);
    
    public static Vector3 AddY(this Vector3 vector, float y)
    {
      vector.y += y;
      return vector;
    }
  }
}