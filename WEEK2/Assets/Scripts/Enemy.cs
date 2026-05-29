using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;
    public float hp = 100f;

    public float attackDistance = 1.5f;

    void Update()
    {
        if (player == null) return;

        Vector3 direction = (player.position - transform.position);
        direction.y = 0f; // 高さ無視（重要）
        direction.Normalize();

        float distance = Vector3.Distance(transform.position, player.position);

        // 近づく
        if (distance > attackDistance)
        {
            transform.position += direction * speed * Time.deltaTime;

            // 向きをプレイヤーへ
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}