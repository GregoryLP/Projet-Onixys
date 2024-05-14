using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tir : MonoBehaviour {

    private Transform target;
    public GameObject bulletArme;
    public GameObject impactEffect;
    public float bulletSpeed = 50f;
    public string enemyTag = "Enemy";

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] ennemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in ennemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("fire");
            GameObject bullet = (GameObject)Instantiate(bulletArme, transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody>().velocity = Vector3.forward.normalized * bulletSpeed;
            Destroy(bullet, 4f);
            Vector3 dir = target.position - transform.position;
            float distanceThisFrame = bulletSpeed * Time.deltaTime;
            if (dir.magnitude <= distanceThisFrame)
            {
                GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
                Destroy(effectIns, 5f);
                Destroy(target.gameObject);
                Destroy(gameObject);
            }

        }
    }
}
