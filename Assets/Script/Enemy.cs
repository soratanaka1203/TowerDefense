using UnityEngine;
using UnityEngine.AI; // NavMesh���g�����߂ɕK�v

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform goal; // �S�[���n�_

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
        // �S�[���ɓ��B�������̏����i��F���C�t�����炷�Ȃǁj
        Destroy(gameObject);
    }
}
