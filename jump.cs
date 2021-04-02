using System;
using UnityEngine;


    public class jump : MonoBehaviour
    {
        private Rigidbody rigidbody;
        [SerializeField] private float jumpForce = 300f;
        private bool shouldJump;

        private void Awake() => rigidbody = GetComponent<Rigidbody>();

        private void Update()
        {
            if (shouldJump == false)
                shouldJump = Input.GetKeyDown(KeyCode.Space);
            
        }

        private void FixedUpdate()
        {
            if (shouldJump)
            {
                rigidbody.AddForce(jumpForce * Vector3.up);
                shouldJump = false;
            }
        }
    }
