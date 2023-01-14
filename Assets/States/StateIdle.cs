using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateIdle : BaseState
{
    public Blob blob;
    void Start()
    {
        blob = gameObject.GetComponent<Blob>();
    }

    void Update()
    {
        blob.moveSpeed = 0f;
    }
}

