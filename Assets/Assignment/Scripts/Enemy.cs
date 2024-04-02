using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : Entity
{
    public Transform playerTransform; //Reference to the player
    public float enemySpeed = 3;

    protected override void Start()
    {
        base.Start();

        //Find player tag
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
    }

    protected override void FixedUpdate() //Paht to player
    {
        if (playerTransform != null)
        {
            //Calculate direction to player
            Vector2 direction = (playerTransform.position - transform.position).normalized;
            //Move to player
            rb.position += direction * moveSpeed * Time.fixedDeltaTime;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Check if the object collided has player component
        Player player = collision.collider.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamage(1);
            Destroy(gameObject);
        }

        //If it gets hit with projectile then die
        Projectile projectile = collision.collider.GetComponent<Projectile>();
        if (projectile != null)
        {
            TakeDamage(1);
        }
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    protected override void Die()
    {
        Destroy(gameObject);
    }
}
