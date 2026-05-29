using UnityEngine;
using System.Collections.Generic;

public class EnemyDetector : MonoBehaviour
{
    public float detectRadius = 15f;
    public LayerMask enemyLayer;

    public List<Transform> enemies = new List<Transform>();
    public Transform currentTarget;

    void Update()
    {
        DetectEnemies();

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SwitchTarget();
        }
    }

    void DetectEnemies()
    {
        enemies.Clear();

        Collider[] hits = Physics.OverlapSphere(transform.position, detectRadius, enemyLayer);

        foreach (var hit in hits)
        {
            enemies.Add(hit.transform);
        }

        if (currentTarget == null && enemies.Count > 0)
        {
            currentTarget = enemies[0];
        }
    }

    void SwitchTarget()
    {
        if (enemies.Count == 0) return;

        int index = enemies.IndexOf(currentTarget);
        index++;

        if (index >= enemies.Count)
            index = 0;

        currentTarget = enemies[index];
    }
}