using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public float Slow = 0.5f;
    float normalValue = 2.5f;

    void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            //Slow down the player
            player.ApplySlow(Slow);
        }

        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            // Destroy the enemy
            Destroy(enemy.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            //Reset to normal speed
            player.ApplyNormal(normalValue);
        }
    }
}
