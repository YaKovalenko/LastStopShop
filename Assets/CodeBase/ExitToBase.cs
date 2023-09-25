using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase
{
    public class ExitToBase : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("LastStopShop/Main");
            }
        }
    }
}
