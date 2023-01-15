﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
public class StateGoToFood : BaseState
{
    public Blob blob;
    public Rigidbody2D rb;

    void Start()
    {
        blob = gameObject.GetComponent<Blob>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        if (!blob.GetNearestFood())
        {
            rb.velocity = -transform.position.normalized;
            return;
        }
        Vector2 lookDir = (blob.GetNearestFood().transform.position - gameObject.transform.position).normalized;
        rb.velocity = lookDir * blob.moveSpeed;
    }
}