using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float fireRate = 1f;
    public GameObject bulletPrefab;
    public Transform firePoint;

    private float fireCooldown = 0f;
    private List<Transform> targets = new List<Transform>();

    [SerializeField] private TowerLookEnemy lookEnemy;

    void Update()
    {
        fireCooldown -= Time.deltaTime;

        if (targets.Count > 0 && fireCooldown <= 0f)
        {
            lookEnemy.target = targets[0];
            Fire(targets[0]); // Å‰‚É“ü‚Á‚Ä‚«‚½“G‚ð‘_‚¤
            fireCooldown = 1f / fireRate;
        }
    }

    void Fire(Transform target)
    {
        GameObject bullet = BulletPool.Instance.GetBullet();
        bullet.transform.position = firePoint.position;
        bullet.GetComponent<Bullet>().SetTarget(target);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("dd");
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("d");
            targets.Add(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            targets.Remove(other.transform);
        }
    }
}
