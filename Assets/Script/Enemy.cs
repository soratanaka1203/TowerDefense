using UnityEngine;
using UnityEngine.AI; // NavMeshを使うために必要

public class Enemy : MonoBehaviour
{
    public Transform[] waypoints; // 経由地リスト
    private NavMeshAgent agent;
    private int currentIndex = 0;

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

    void ReachGoal()
    {
        // ゴール処理（HP減らすなど）
        Destroy(gameObject);
    }
}
