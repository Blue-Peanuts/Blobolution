using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class MasterManager : MonoBehaviour
{
    public static MasterManager Instance;
    
    private const int NewBlobThreshold = 20;
    private const int OriginalPelletEnergy = 3;
    private const int OriginalBlobEnergy = 30;
    
    private int EnergyLevel => GetComponent<Energy>().energyLevel;
    [HideInInspector]
    public int blobCount = 0;

    public GameObject blobPrefab;
    [SerializeField] private GameObject pelletPrefab;

    private void Awake()
    {
        Instance = this;
        StartCoroutine(DrainAll());
    }
    IEnumerator DrainAll()
    {
        print('a');
        foreach (var VARIABLE in FindObjectsOfType<Blob>())
        {
            GetComponent<Energy>().Drain(1, VARIABLE.GetComponent<Energy>());
        }

        yield return new WaitForSeconds(1);
        StartCoroutine(DrainAll());
    }

    private void Update()
    {
        if (blobCount < NewBlobThreshold) //if we need new blobs
        {
            if (EnergyLevel > OriginalBlobEnergy)
            {
                CreateBlob();
            }
        }
        else if (EnergyLevel > OriginalPelletEnergy) //if we dont need new blobs
        {
            CreatePellets();
        }

    }

    private void CreateBlob()
    {
        GameObject blob = Instantiate(blobPrefab, (Vector3)Random.insideUnitCircle * 30, quaternion.identity);
        Gene.RandomGene(blob);
        blob.GetComponent<Energy>().Drain(OriginalBlobEnergy,GetComponent<Energy>());
    }
    private void CreatePellets()
    {        
        GameObject blob = Instantiate(pelletPrefab, (Vector3)Random.insideUnitCircle * 60, quaternion.identity);
        blob.GetComponent<Energy>().Drain(OriginalPelletEnergy,GetComponent<Energy>());
    }
}
