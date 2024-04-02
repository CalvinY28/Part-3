using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Entity
{
    public Transform target;
    public float projectileSpeed = 10;
    public float rotateSpeed = 200;

    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();

        // Find player, set as target
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            target = playerObject.transform;
        }
    }

    protected override void FixedUpdate()
    {
        if (target == null) return;

        //Direction to target
        Vector2 direction = (Vector2)target.position - rb.position;
        direction.Normalize();
        //Testing something here, made projectiles go in circles kind of
        //Rotation to target
        float rotateAmount = Vector3.Cross(direction, transform.up).z;

        // Apply angular velocity
        rb.angularVelocity = -rotateAmount * rotateSpeed;

        rb.velocity = transform.up * projectileSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Entity entity = collision.collider.GetComponent<Entity>();
        if (entity != null)
        {
            //Apply damage
            entity.TakeDamage(1);
        }

        //Destroy on impact
        Destroy(gameObject);
    }

}
