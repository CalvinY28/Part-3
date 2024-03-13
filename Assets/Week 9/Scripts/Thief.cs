using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Thief : Villager
{

    public GameObject daggerPrefab;
    public Transform spawnPoint;
    public Transform spawnPoint2;
    private bool attack = false;

    public override ChestType CanOpen()
    {
        return ChestType.Theif;
    }

    protected override void Attack()
    {
        attack = true;
        dash();
        destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        base.Attack();
        Instantiate(daggerPrefab, spawnPoint.position, spawnPoint.rotation);
        Instantiate(daggerPrefab, spawnPoint2.position, spawnPoint2.rotation);
        if (Input.GetMouseButtonDown(0)){
            speed = 3;
            attack = false;
        }
    }

    void dash() {
        if (attack == true) {
            speed = 50;
        }
        if (attack == false) {
            speed = 3;
        }
    }
}
