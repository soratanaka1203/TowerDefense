using UnityEngine;
using UnityEngine.AI; // NavMesh���g�����߂ɕK�v

public class Enemy : MonoBehaviour
{
    public Transform[] waypoints; // �o�R�n���X�g
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
        // �S�[�������iHP���炷�Ȃǁj
        Destroy(gameObject);
    }
}
