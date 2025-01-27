using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [Header("Player Inventory")]
    public PlayerInventory playerInventory;
    public GameObject keyItem;
    
    [Header("Player Movement")]
    [SerializeField] private float turnSpeed; 
    private bool _isGrounded; 
    private Rigidbody _rb;
    private float currentAngle; 
    private float currentAngleVelocity;
    [SerializeField] private float speed = 5.0f, jumpHeight = 5.0f, gravity = 10f; 
    private float _rotInput;
    

    private Vector3 _input;
    public bool[] hasKey = new bool[2];
    public bool isWarping;
    
    private MyMethods MyMethods;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        playerInventory.Container.Clear();
        MyMethods = gameObject.AddComponent<MyMethods>();
    }
    
    private void Update()
    {
        Move();
        
        Jump();
        
    }

    private void Move()
    {
        _input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        
        if (_input.magnitude >= 0.1f)
        {
            // Calculate the angle to rotate the player
            float targetAngle = Mathf.Atan2(_input.x, _input.z) * Mathf.Rad2Deg;
            currentAngle = Mathf.SmoothDampAngle(currentAngle, targetAngle, ref currentAngleVelocity, turnSpeed);
            transform.rotation = Quaternion.Euler(0, targetAngle, 0);
            
            // Player movement
            Vector3 moveCorrect = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            transform.localPosition += speed * Time.deltaTime * moveCorrect;
        }
    }

    private void Jump()
    {
        if (!_isGrounded)
        {
            //This will fix a bug where the player is not fully on the ground, making the _isGrounded bool false.
            _rb.AddForce(Vector3.down * gravity);
        }
        
        //Handling jumping
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            _isGrounded = false;
        }
    }
    
    private void OnCollisionEnter (Collision hit)
    {
        switch (hit.gameObject.tag)
        {
            case "Ground":
                _isGrounded = true;
                break;
        }
    }

    private void OnTriggerEnter(Collider hit)
    {
        switch (hit.gameObject.tag)
        {
            case "OOB":
                transform.position = new Vector3(9, 1, 0);
                break;
            case "dimensionMain":
                isWarping = false;
                break;
            case "dimensionFuture":
                isWarping = true;
                break;
        }
        
        switch (hit.GetComponent<MonoBehaviour>())
        {
            case Item item:
                playerInventory.AddItem(item.item, 1);
                Destroy(hit.gameObject);
                switch (hit.gameObject.tag)
                {
                    case "keyItem1":
                        if(hasKey.Length > 0)
                            hasKey[0] = true;
                        break;
                    case "keyItem2":
                        if(hasKey.Length > 1)
                            hasKey[1] = true;
                        break;
                }
                break;
        }
        
        
        
    }
    private void OnApplicationQuit()
    {
        playerInventory.Container.Clear();
    }
    
}
