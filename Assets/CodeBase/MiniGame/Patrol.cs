using System;
using System.Collections;
using System.Collections.Generic;
using CodeBase.Loot;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace CodeBase.MiniGame
{
    public class Patrol : MonoBehaviour
    {
        public float speed;
        public Transform[] points;
        public int i;

        [SerializeField] private MiniGameLootItem _lastClickedItem;
        [SerializeField] private LootManager _lootManager;

        private void FixedUpdate()
        {
            transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, points[i].position) < 0.2f)
            {
                if (i > 0)
                    i = 0;
                else i = 1;
            }
        
        }

        private void OnTriggerStay(Collider other)
        {
            Debug.Log("Colliders");
            _lastClickedItem = other.GetComponent<MiniGameLootItem>();
        }

        public void LootSender()
        {
            Debug.Log("Ebanaya knopka click");
            if(_lastClickedItem != null)
                SendLoot();
        }


        private void SendLoot()
        {
            _lootManager.AddLoot(_lastClickedItem.GetItemData());
            EventManager.OnMiniGameEnded();
        }
    }
}
