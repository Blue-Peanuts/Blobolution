using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blob : MonoBehaviour
{
    public Energy energy;
    public Energy food;

    // Start is called before the first frame update
    void Start()
    {
        energy = gameObject.GetComponent<Energy>();
        food = GameObject.FindGameObjectWithTag("Food").GetComponent<Energy>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Food")
        {
            energy.Drain(food.energyLevel, food);
        }
    }
}