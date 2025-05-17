using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    private Transform target;
    private Rigidbody _rb;


    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void SetTarget(Transform targetTransform)
    {
        target = targetTransform;
    }

    void Update()
    {
        if (target == null)
        {
            BulletPool.Instance.ReturnBullet(gameObject);
            return;
        }

        Vector3 dir = (target.position - transform.position).normalized;
        //transform.position += dir * speed * Time.deltaTime;
        _rb.velocity = dir * speed;

    }



    private void OnCollisionEnter(Collision collision)
    {
        HitOther();
    }

    private void HitOther()
    {
        BulletPool.Instance.ReturnBullet(gameObject);
    }
}
