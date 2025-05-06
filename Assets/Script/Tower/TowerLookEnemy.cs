using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerLookEnemy : MonoBehaviour
{

    public Transform target;

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            // �G�̈ʒu�iY������������Y�ɍ��킹��j
            Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, target.position.z);

            transform.LookAt(target);
        }
    }
}
