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
    
    private const int NewBlobThreshold = 50;
    private const int OriginalPelletEnergy = 3;
    private const int OriginalBlobEnergy = 30;

    public float timeScale;
    
    private int EnergyLevel => GetComponent<Energy>().energyLevel;
    [HideInInspector]
    public int blobCount = 0;

    public GameObject blobPrefab;
    [SerializeField] private GameObject pelletPrefab;

    private void Awake()
    {
        Instance = this;
        StartCoroutine(DrainAll());
        StartCoroutine(PelletLoop());

    }
    IEnumerator DrainAll()
    {
        foreach (var VARIABLE in FindObjectsOfType<Blob>())
        {
            GetComponent<Energy>().Drain(1, VARIABLE.GetComponent<Energy>());
        }

        yield return new WaitForSeconds(1);
        StartCoroutine(DrainAll());
    }

    IEnumerator PelletLoop()
    {
        yield return new WaitForSeconds(0.1f);
        if (EnergyLevel > OriginalPelletEnergy && (blobCount >= NewBlobThreshold))
        {
            CreatePellets();
        }
        StartCoroutine(PelletLoop());
    }

    private void Update()
    {
        Time.timeScale = timeScale;
        if (blobCount < NewBlobThreshold) //if we need new blobs
        {
            if (EnergyLevel > OriginalBlobEnergy)
            {
                CreateBlob();
            }
        }

    }

    private void CreateBlob()
    {
        GameObject blob = Instantiate(blobPrefab, (Vector3)Random.insideUnitCircle * 100, quaternion.identity);
        Gene.RandomGene(blob);
        blob.GetComponent<Energy>().Drain(OriginalBlobEnergy,GetComponent<Energy>());
    }
    private void CreatePellets()
    {        
        GameObject blob = Instantiate(pelletPrefab, (Vector3)Random.insideUnitCircle * 170, quaternion.identity);
        blob.GetComponent<Energy>().Drain(OriginalPelletEnergy,GetComponent<Energy>());
    }
}
