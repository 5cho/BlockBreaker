using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private float horizontalInput;
    private Rigidbody2D playerRigidBody;
    private void Awake()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        GetInput();
    }
    private void FixedUpdate()
    {
        Vector2 moveVector = new Vector2(horizontalInput * moveSpeed, 0f);
        playerRigidBody.AddForce(moveVector, ForceMode2D.Force);
    }
    private void GetInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
    }
}
