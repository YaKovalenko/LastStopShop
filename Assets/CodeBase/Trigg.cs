using UnityEngine;

namespace CodeBase
{
  public class Trigg : MonoBehaviour
  {
    public bool k = false;
    public string Name = "";

    private void OnTriggerEnter2D(Collider2D other)
    {
      k = true;
      Name = other.name;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
      k = false;
      Name = "";
    }

    void Update()
    {
      if (Input.GetMouseButtonDown(0) && k == true)
      {
        Debug.Log(Name);
      }
    }
  }
}