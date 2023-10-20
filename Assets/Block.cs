using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    private bool shouldSpawnPowerup = false;
    [SerializeField] private Transform spawnPowerup;

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (shouldSpawnPowerup)
        {
            Instantiate(spawnPowerup, transform.position, Quaternion.identity);
        }
        BBGameManager.Instance.DestroyBlock(this);
        Destroy(gameObject);
    }
    public void SetBlockToSpawnPowerup(Transform powerupToSpawn)
    {
        shouldSpawnPowerup = true;
        spawnPowerup = powerupToSpawn;

        spriteRenderer.color = Color.blue;
    }
}
