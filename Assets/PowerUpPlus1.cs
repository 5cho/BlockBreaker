using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPlus1 : MonoBehaviour
{
    private float dropSpeed = 1f;
    private void Update()
    {
        gameObject.transform.position += Vector3.down * Time.deltaTime * dropSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out Player player))
        {
            BBGameManager.Instance.SpawnNewBall();
            Destroy(gameObject);
        }
    }
}
