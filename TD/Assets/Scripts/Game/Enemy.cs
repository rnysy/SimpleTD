using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    public int health = 100;

    public int moneyGain = 50;

    public GameObject deathEffect;

    public Transform target;
    private int wavePointIndex = 0;

    void Start()
    {
        target = WayPoint.points[0];
    }

    public void TakeDamage(int amount)
    {
        Debug.Log("체력까임");
        health -= amount;
        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Debug.Log("죽음");
        PlayerStat.Money += moneyGain;
        Destroy(gameObject);
    }

    void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWayPoint();
        }
    }

    void GetNextWayPoint()
    {
        if (wavePointIndex >= WayPoint.points.Length - 1)
        {
            EndPath();
            return;
        }

        wavePointIndex++;
        target = WayPoint.points[wavePointIndex];
    }

    void EndPath()
    {
        PlayerStat.Lives--;
        Destroy(gameObject);
    }
}
