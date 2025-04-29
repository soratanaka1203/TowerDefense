using UnityEngine;
using UnityEngine.AI; // NavMeshを使うために必要

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform goal; // ゴール地点

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (goal != null)
        {
            agent.SetDestination(goal.position);
        }
    }

    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            ReachGoal();
        }
    }

    void ReachGoal()
    {
        // ゴールに到達した時の処理（例：ライフを減らすなど）
        Destroy(gameObject);
    }
}
