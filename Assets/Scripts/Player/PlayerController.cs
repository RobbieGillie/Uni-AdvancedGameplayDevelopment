using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private float gravity = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private bool canJump = true;

    [Header("Ground Check")] 
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody rb;
    private Vector3 velocity;
    private bool isGrounded;
    
    
    private void Start()
    {
        
    }

    private void Update()
    {
        
    }
}
