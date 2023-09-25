using UnityEngine;

namespace CodeBase
{
    public class Patrol : MonoBehaviour
    {
        public float speed;
        public Transform[] points;
        public int i;


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
                speed = 0;
                Debug.Log(Name);
            }
        }
    }
}
