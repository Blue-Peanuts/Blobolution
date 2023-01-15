using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StateGoToEnemy : BaseState
{
    public Blob blob;
    public Rigidbody2D rb;
    private float delayForBite = 1;
    private float biteCDNow = 1;
    void Start()
    {
        blob = gameObject.GetComponent<Blob>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (biteCDNow <= 0)
        {
            Bite();
            biteCDNow = delayForBite;
        }

        biteCDNow -= Time.deltaTime;
    }
    void Bite()
    {
        foreach (var foe in GetComponent<Blob>().GetAllNearEnemies(1.5f))
        {
            if(!foe.GetComponent<StateGoToEnemy>() || foe.GetComponent<StateGoToEnemy>().enabled == false || GetComponent<Energy>().energyLevel > foe.GetComponent<Energy>().energyLevel)
                GetComponent<Energy>().Drain(20,foe.GetComponent<Energy>());
        }
    }
    void FixedUpdate()
    {
        if (!blob.GetNearestEnemy())
        {
            
            rb.velocity = -transform.position.normalized;
            return;
        }
        Vector2 lookDir = (blob.GetNearestEnemy().transform.position - gameObject.transform.position).normalized;
        rb.velocity = lookDir * blob.moveSpeed;
    }
}