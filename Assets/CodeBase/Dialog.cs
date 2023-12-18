using System.Collections;
using TMPro;
using UnityEngine;

namespace CodeBase
{
    public class Dialog : MonoBehaviour
    {
        public TextMeshProUGUI textDisplay;
        public GameObject dialogPanel;
        public string[] sentences;
        private int index;
        public float typingSpeed;
        public bool playerIsClose;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
            {
                if (dialogPanel.activeInHierarchy)
                {
                    ZeroText();
                }
                else
                {
                    dialogPanel.SetActive(true);
                    StartCoroutine(Type());
                }
            }
            else if(Input.GetKeyDown(KeyCode.RightArrow) && playerIsClose)
            {
                NextSentence();
            }
        }

        IEnumerator Type()
        {
            foreach (char letter in sentences[index].ToCharArray())
            {
                textDisplay.text += letter;
                yield return new WaitForSeconds(typingSpeed);
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
                ZeroText();
            }
        }

        public void ZeroText()
        {
            textDisplay.text = "";
            index = 0;
            dialogPanel.SetActive(false);
        }

        public void NextSentence()
        {
            if (index < sentences.Length - 1)
            {
                index++;
                textDisplay.text = "";
                StartCoroutine(Type());
            }
            else
            {
                textDisplay.text = "";
                dialogPanel.SetActive(false);
            }
        }
    }
}
