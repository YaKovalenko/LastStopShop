using System;
using System.Collections;
using System.Collections.Generic;
using CodeBase.Infrastructure;
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
        [SerializeField] private List<ItemSO> _lastClickedItems;
        [SerializeField] private LootManager _lootManager;
        [SerializeField] private GameObject _cursor;

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

        private void OnTriggerEnter2D(Collider2D other)
        {
           
            _lastClickedItem = other.GetComponent<MiniGameLootItem>();
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
           
            _lastClickedItem = null;
        }

        public void LootSender()
        {
            if (_lastClickedItem != null)
            {
                _lastClickedItems.Add(_lastClickedItem.GetItemData());
                SendLoot();
            }
        }


        private void SendLoot()
        {
            _lootManager.AddLoot(_lastClickedItems);
            speed = 0;
            _cursor.SetActive(false);
            //EventManager.OnMiniGameEnded();
        }
    }
}
