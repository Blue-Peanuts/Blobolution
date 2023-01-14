using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MasterManager : MonoBehaviour
{
    private const int NewBlobThreshold = 20;
    private const int OriginalPelletEnergy = 3;
    private const int OriginalBlobEnergy = 30;
    
    private int EnergyLevel => 0;
    [HideInInspector]
    public int blobCount = 0;

    [SerializeField] private GameObject blobPrefab;
    [SerializeField] private GameObject pelletPrefab;
    
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
        //Blob should drain energy from this
    }
    private void CreatePellets()
    {
        //Pellet should drain energy from this
    }
}
