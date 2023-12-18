using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CodeBase.Customer
{
    public class Customer : MonoBehaviour
    {
        [SerializeField] private Transform vfxSpawn;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private GameObject _stuff;
        public TextMeshProUGUI textDisplay;
        public GameObject dialogPanel;

        private void Start()
        {
            CoffinSelector.PlayerWon += OnSpawnWinVFX;
            CoffinSelector.PlayerLose += OnSpawnLose;
        }

        private void OnSpawnLose()
        {
            dialogPanel.SetActive(true);
            textDisplay.text = "Hm… I'm not sure this is what I need.";
            StartCoroutine(DestroyDelay());
        }

        private void OnSpawnWinVFX()
        {
            dialogPanel.SetActive(true);
            textDisplay.text = "We appreciate your help. My dog and I have always been together, our souls are intertwined." +
                               "That’s the symbol of our connection and eternal friendship… Thank you a lot.";
            _stuff.SetActive(true);
            Instantiate(vfxSpawn, spawnPoint.position, spawnPoint.rotation);
            StartCoroutine(DestroyDelay());
        }

        private IEnumerator DestroyDelay()
        {
            yield return new WaitForSeconds(3);
            Destroy(gameObject);
            textDisplay.text = "";
            dialogPanel.SetActive(false);
           
        }
    }
}
