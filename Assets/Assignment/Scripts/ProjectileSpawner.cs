using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float spawnRate = 2;

    void Start()
    {
        StartCoroutine(SpawnProjectileCorutine());
    }

    IEnumerator SpawnProjectileCorutine()
    {
        //Infinite loop
        while (true)
        {
            SpawnProjectile();
            yield return new WaitForSeconds(spawnRate);
        }
    }

    void SpawnProjectile() //Just testing something
    {
        if (projectilePrefab != null)
        {
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        }
    }
}
