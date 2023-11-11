using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase
{
    public class OpenMiniGameScene : MonoBehaviour
    {
        public bool playerIsClose = false;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
            {
                SceneManager.LoadScene("Minigame");
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                playerIsClose = true;
            }
        }
    
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                playerIsClose = false;
            }
        }
    }
}
