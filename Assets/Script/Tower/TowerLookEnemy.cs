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
            // “G‚ÌˆÊ’uiY²‚¾‚¯©•ª‚ÌY‚É‡‚í‚¹‚éj
            Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, target.position.z);

            transform.LookAt(target);
        }
    }
}
