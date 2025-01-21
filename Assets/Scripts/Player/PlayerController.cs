using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float turnSpeed; private bool _isGrounded; private Rigidbody _rb;
    float currentAngle; float currentAngleVelocity;
    public float speed = 5.0f, jumpHeight = 5.0f, gravity = 10f; private float _rotInput;
    
    private Vector3 _input;
    private Camera _camera;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _camera = Camera.main;
    }
    
    private void Update()
    {
        _input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        Move();
        
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            Jump();
        }
        
        if (!_isGrounded)
        {
            _rb.AddForce(Vector3.down * gravity);
        }
        
        
    }

    private void Move()
    {
        if (_input.magnitude >= 0.1f)
        {
            // Calculate the angle to rotate the player
            float targetAngle = Mathf.Atan2(_input.x, _input.z) * Mathf.Rad2Deg + _camera.transform.eulerAngles.y;
            currentAngle = Mathf.SmoothDampAngle(currentAngle, targetAngle, ref currentAngleVelocity, turnSpeed);
            transform.rotation = Quaternion.Euler(0, targetAngle, 0);
            // Player movement
            Vector3 moveCorrect = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            transform.localPosition += speed * Time.deltaTime * moveCorrect;
        }
    }

    private void Jump()
    {
        _rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        _isGrounded = false;
    }
    
    
    private void OnCollisionEnter (Collision hit)
    {
        if (hit.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }
    
}
