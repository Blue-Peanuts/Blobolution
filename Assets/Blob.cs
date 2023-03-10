using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Blob : MonoBehaviour
{
    public Energy energy;
    public float moveSpeed = 1f;
    [SerializeField] private ParticleSystem[] particleSystems;
    [SerializeField] private SpriteRenderer spriteRenderer; 

    // Start is called before the first frame update
    void Start()
    {
        energy = gameObject.GetComponent<Energy>();
        MasterManager.Instance.blobCount++;
    }

    

    private void OnDestroy()
    {
        MasterManager.Instance.blobCount--;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<Gene>())
            return;
        if (energy.energyLevel > 90)
        {
            GiveBirth();
        }

        foreach (var particle in particleSystems)
        {
            ParticleSystem.MainModule particleMain = particle.main;
            particleMain.startColor = new Color(
                GetComponent<Gene>().RedPigment,GetComponent<Gene>().BluePigment,GetComponent<Gene>().GreenPigment);
        }
        spriteRenderer.color = new Color(
            GetComponent<Gene>().RedPigment,GetComponent<Gene>().BluePigment,GetComponent<Gene>().GreenPigment);

        if (Vector3.Distance(transform.position, Vector3.zero) > 180)
        {
            transform.position = -transform.position;
            transform.position += (Vector3.zero - transform.position).normalized * 5;
        }
    }

    void GiveBirth()
    {
        GameObject son = Instantiate(MasterManager.Instance.blobPrefab,transform.position, Quaternion.identity);
        GetComponent<Gene>().Mutate(son);
        son.GetComponent<Energy>().Drain(50, GetComponent<Energy>());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            energy.Drain(collision.gameObject.GetComponent<Energy>().energyLevel, collision.gameObject.GetComponent<Energy>());
        }
    }

    public Collider2D[] FindAllNearTaggedObject(string targetTag, float radius)
    {
        Vector2 currentPosition = transform.position;
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(currentPosition, radius);
        List<Collider2D> hitCollidersList = hitColliders.ToList();
        hitCollidersList.Remove(GetComponent<Collider2D>());

        List<Collider2D> finalColliders = new List<Collider2D>();
        
        foreach (var VARIABLE in hitCollidersList)
        {
            if(VARIABLE.gameObject.CompareTag(targetTag))
                finalColliders.Add(VARIABLE);
        }
        return finalColliders.ToArray();
    }
    
    public GameObject FindNearestOfGroup(Collider2D[] group, float radius) {
        
        Vector2 currentPosition = transform.position;
        GameObject nearestTaggedObject = null;
        float nearestDistance = radius;

        for (int i = 0; i < group.Length; i++) {
            if (group[i].gameObject != gameObject) {
                float distance = Vector2.Distance(group[i].transform.position, currentPosition);
                if (distance < nearestDistance) {
                    nearestTaggedObject = group[i].gameObject;
                    nearestDistance = distance;
                }
            }
        }
        return nearestTaggedObject;
    }
    public float GetDistanceToNearestOfGroup(Collider2D[] group, float radius) {
        GameObject nearestTaggedObject = FindNearestOfGroup(group, radius);
        if (nearestTaggedObject != null) {
            return Vector2.Distance(nearestTaggedObject.transform.position, transform.position);
        }
        return 100000;
    }

    public Collider2D[] GetAllNearEnemies(float radius)
    {
        List<Collider2D> oldGroup = FindAllNearTaggedObject("Blob", radius).ToList();
        List<Collider2D> newGroup = new List<Collider2D>();
        foreach (var col in oldGroup)
        {
            if(!GetComponent<Gene>().IsFriendsWith(col.gameObject.GetComponent<Gene>()))
                newGroup.Add(col);
        }

        return newGroup.ToArray();
    }
    public Collider2D[] GetAllNearFriends(float radius)
    {
        List<Collider2D> oldGroup = FindAllNearTaggedObject("Blob", 20).ToList();
        List<Collider2D> newGroup = new List<Collider2D>();
        foreach (var col in oldGroup)
        {
            if(GetComponent<Gene>().IsFriendsWith(col.gameObject.GetComponent<Gene>()))
                newGroup.Add(col);
        }

        return newGroup.ToArray();
    }

    public GameObject GetNearestEnemy()
    {
        return FindNearestOfGroup(GetAllNearEnemies(20), 20);
    }
    public GameObject GetNearestFriend()
    {
        return FindNearestOfGroup(GetAllNearEnemies(20), 20);
    }
    public GameObject GetNearestFood()
    {
        return FindNearestOfGroup(FindAllNearTaggedObject("Food", 20), 20);
    }
}