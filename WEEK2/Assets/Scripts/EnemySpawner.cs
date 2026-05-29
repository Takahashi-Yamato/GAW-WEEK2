using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform player;

    public float spawnInterval = 3f;
    public float spawnRadius = 10f;

    void Start()
    {
        InvokeRepeating(nameof(Spawn), 1f, spawnInterval);
    }

    void Spawn()
    {
        Vector3 randomPos = transform.position + Random.insideUnitSphere * spawnRadius;
        randomPos.y = transform.position.y;

        GameObject enemy = Instantiate(enemyPrefab, randomPos, Quaternion.identity);

        Enemy e = enemy.GetComponent<Enemy>();
        e.player = player;
    }
}