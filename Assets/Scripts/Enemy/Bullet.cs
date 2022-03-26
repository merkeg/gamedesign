using System;
using Entity;
using UnityEngine;

namespace Enemy
{
    public class Bullet : MonoBehaviour
    {

        private Collider2D _collider;
        private Rigidbody2D _rigidbody;
        
        public Direction Direction = Direction.Right;
        
        [Range(0.5f, 10f)]
        public float SpeedMultiplier = 1;
        
        
        private void Start()
        {
            _collider = GetComponent<CircleCollider2D>();
            _rigidbody = GetComponent<Rigidbody2D>();

        }

        private void Update()
        {
            Vector3 position = transform.localPosition;
            transform.localPosition = new Vector3(position.x + ((int) Direction) * Time.deltaTime * SpeedMultiplier, position.y, position.z);
            // _rigidbody.AddForce(new Vector2(position.x + ((int) Direction) * Time.deltaTime * SpeedMultiplier, 0));
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.transform == transform.parent)
            {
                return; // Return if collider is parent
            }

            Damageable damageable = other.gameObject.GetComponent<Damageable>();
            if (damageable != null)
            {
                Debug.Log("Do Damage");
                damageable.TakeDamage();
            }
            Destroy(gameObject);
        }
    }
    public enum Direction
    {
        Right = 1,
        Left = -1
    }
}