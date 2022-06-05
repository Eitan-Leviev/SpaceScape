using System;
using UnityEngine;

namespace gilad.Scripts
{
    public class Vent : MonoBehaviour
    {

        [SerializeField] private float turnSpeed = 0.01f;
        [SerializeField] private float speed = 1f;

        [SerializeField] private AudioSource sound;

        private float _moveSpeed = 1f;
        // Start is called before the first frame update

        private Transform _ball = null;

        private Animator _animator;
        void Start()
        {
            _animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            // print("trigger enter");
            _ball = other.gameObject.transform;
            // if(_animator != null)_animator.SetBool("Fast", true);
            _moveSpeed = _ball.GetComponent<BallEitan>().initSpeed * speed;
            if(sound != null)sound.Play();
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            _ball = null;
            if(sound != null)sound.Pause();
        }

        private void FixedUpdate()
        {
            if (_ball != null)
            {
                var ballRB = _ball.gameObject.GetComponent<Rigidbody2D>();
            
                var normal = (_ball.position - transform.position);
                if (normal.magnitude > Math.Abs(_moveSpeed))
                {
                    normal = normal.normalized;
                }
                // normal = normal.normalized;
                normal *= _moveSpeed;
                var curVelocity = ballRB.velocity;
                ballRB.velocity = Vector2.MoveTowards(curVelocity, normal, turnSpeed);

            }
        
        }
    }
}
