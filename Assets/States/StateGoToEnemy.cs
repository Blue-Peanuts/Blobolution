using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StateGoToEnemy : BaseState
{
    public Blob blob;
    public Rigidbody2D rb;
    public float moveSpeed = 1f;

    void Start()
    {
        blob = gameObject.GetComponent<Blob>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        Vector2 lookDir = (blob.GetNearestEnemy().transform.position - gameObject.transform.position).normalized;
        rb.velocity = lookDir;
    }
}