using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CodeBase.Customer
{
    public class Customer : MonoBehaviour
    {
        [SerializeField] private Transform vfxSpawn;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private GameObject _stuff;

        private void Start()
        {
            CoffinSelector.PlayerWon += OnSpawnWinVFX;
        }

        private void OnSpawnWinVFX()
        {
            _stuff.SetActive(true);
            Instantiate(vfxSpawn, spawnPoint.position, spawnPoint.rotation);
            StartCoroutine(DestroyDelay());
        }

        private IEnumerator DestroyDelay()
        {
            yield return new WaitForSeconds(3);
            Destroy(gameObject);
           
        }
    }
}
