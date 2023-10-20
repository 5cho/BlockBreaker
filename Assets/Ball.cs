using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] private float launchSpeed = 10f;
    [SerializeField] private float velocity = 10f;
    private bool followPlayer = false;
    private float xFollowOffset;
    private Rigidbody2D ballRigidBody;
    private void Awake()
    {
        ballRigidBody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (followPlayer)
        {
            
            transform.position = new Vector3(BBGameManager.Instance.GetPlayerXPosition() + xFollowOffset, transform.position.y, transform.position.z);
        }
        if(transform.position.y < -9)
        {
            BBGameManager.Instance.DestroyBall(this);
            Destroy(gameObject);
        }

        Vector2 direction = ballRigidBody.velocity.normalized;
        ballRigidBody.velocity = direction * velocity;
    }
    public void SpawnBallAddForce()
    {
        Vector2 direction = new Vector2(Random.Range(-0.6f, 0.6f), 1);
        ballRigidBody.AddForce(direction * launchSpeed, ForceMode2D.Impulse);
    }
    public void SetFollowPlayer()
    {
        followPlayer = true;

        xFollowOffset = transform.position.x - BBGameManager.Instance.GetPlayerXPosition();
    }
    public void SetUnFollowPlayer()
    {
        followPlayer = false;

        xFollowOffset = 0f;

        SpawnBallAddForce();
    }
}
