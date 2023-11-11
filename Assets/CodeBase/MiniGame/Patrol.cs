using System;
using System.Collections;
using CodeBase.Loot;
using UnityEngine;
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
        public bool k = false;
        public string Name = "";

        private void OnTriggerEnter2D(Collider2D other)
        {
            k = true;
            Name = other.name;
            _lastClickedItem = other.GetComponent<MiniGameLootItem>();
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            k = false;
            Name = "";
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.E) && k == true)
            {
                speed = 0;
                Debug.Log(Name);
                if(_lastClickedItem != null)
                    SendLoot();

            }
        }

        private void SendLoot()
        {
            _lootManager.AddLoot(_lastClickedItem.GetItemData());
            EventManager.OnMiniGameEnded();
        }
    }
}
