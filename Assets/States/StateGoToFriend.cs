using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StateGoToFriend : BaseState
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
        if (!blob.GetNearestFriend())
            return;
        Vector2 lookDir = (blob.GetNearestFriend().transform.position - gameObject.transform.position).normalized;
        rb.velocity = lookDir * blob.moveSpeed;
    }
}