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
            Fire(targets[0]); // 最初に入ってきた敵を狙う
            fireCooldown = 1f / fireRate;
        }
    }

    void OnEnable()
    {
        Enemy.OnEnemyDeath += HandleEnemyDeath;
    }

    void OnDisable()
    {
        Enemy.OnEnemyDeath -= HandleEnemyDeath;
    }

    void HandleEnemyDeath(Transform enemy)
    {
        targets.Remove(enemy);
    }


    void Fire(Transform target)
    {
        GameObject bullet = BulletPool.Instance.GetBullet();
        bullet.transform.position = firePoint.position;
        bullet.GetComponent<Bullet>().SetTarget(target);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
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
