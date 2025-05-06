using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    private Transform target;

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
        transform.position += dir * speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            // ƒ_ƒ[ƒWˆ—‚È‚Ç‚ ‚ê‚Î‚±‚±‚É‘‚­

            BulletPool.Instance.ReturnBullet(gameObject);
        }
    }
}
