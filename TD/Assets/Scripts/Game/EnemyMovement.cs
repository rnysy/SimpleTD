using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    public Transform target;
    private int wavePointIndex = 0;

    private Enemy enemy;

    void Start()
    {
        enemy = GetComponent<Enemy>();
        target = WayPoint.points[0];
    }

    void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWayPoint();
        }

        enemy.speed = enemy.startSpeed;
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
