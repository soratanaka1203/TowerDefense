using UnityEngine;
using UnityEngine.AI; // NavMeshを使うために必要

public class Enemy : MonoBehaviour
{
    public Transform[] waypoints; // 経由地リスト
    private NavMeshAgent agent;
    private int currentIndex = 0;

    private int hp = 5;

    public delegate void EnemyDeathHandler(Transform enemy);
    public static event EnemyDeathHandler OnEnemyDeath;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (waypoints.Length > 0)
        {
            agent.SetDestination(waypoints[0].position);
        }
    }

    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            currentIndex++;
            if (currentIndex < waypoints.Length)
            {
                agent.SetDestination(waypoints[currentIndex].position);
            }
            else
            {
                ReachGoal();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("hit");
        if (collision.gameObject.CompareTag("Bullet")) {
            HitBullet();
        }

    }

    private void HitBullet()
    {
        hp--;
        if (hp <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        // 死亡処理
        OnEnemyDeath?.Invoke(transform);
        Destroy(gameObject);
    }

    void ReachGoal()
    {
        // ゴール処理（HP減らすなど）
        Destroy(gameObject);
    }
}
