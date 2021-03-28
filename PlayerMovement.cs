using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]  float _speed = 5f;
    [SerializeField]  LayerMask _aimLayermask;
    
    Animator _animator;

    void Awake() => _animator = GetComponent<Animator>();
    
    void Update()
    {
        AimTowardMouse();
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3(horizontal, 0f, vertical);

        if (movement.magnitude > 0)
        {
            movement.Normalize();
            movement *= _speed * Time.deltaTime;
            transform.Translate(movement, Space.World);
        }

        float VelocityZ = Vector3.Dot(movement.normalized, transform.forward);
        float VelocityX = Vector3.Dot(movement.normalized, transform.right);
        
        _animator.SetFloat("VelocityZ", VelocityZ, 0.1f, Time.deltaTime );
        _animator.SetFloat("VelocityX", VelocityX, 0.1f, Time.deltaTime);
    }

    void AimTowardMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hitinfo, Mathf.Infinity, _aimLayermask))
        {
            var _direction = hitinfo.point - transform.position;
            _direction.y = 0f;
            _direction.Normalize();
            transform.forward = _direction;
        }

    }
}
