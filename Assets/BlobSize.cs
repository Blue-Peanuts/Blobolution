using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobSize : MonoBehaviour
{
    public Energy energy;
    // Start is called before the first frame update
    void Start()
    {
        energy = gameObject.GetComponent<Energy>();
    }

    // Update is called once per frame
    void Update()
    {
        float finalScale = energy.energyLevel / 100f * 0.6f +0.7f;
        gameObject.transform.localScale = Vector3.one * finalScale;
    }
}
