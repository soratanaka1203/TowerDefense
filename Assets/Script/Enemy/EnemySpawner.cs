using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;   // “G‚ÌƒvƒŒƒnƒu
    public Transform spawnPoint;     // “G‚ÌoŒ»ˆÊ’u
    [SerializeField] private Transform[] waypoints;//“G‚ÌŒo—R’n

    public int enemiesPerWave = 5;   // 1Wave‚ ‚½‚è‚Ì“G”
    public float spawnInterval = 1f; // “G“¯m‚ÌŠÔŠui•bj
    public float waveInterval = 60f;  // Wave‚ÌŠÔ‚Ì‘Ò‚¿ŠÔi•bj

    private int currentWave = 0;

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        while (true)
        {
            currentWave++;

            for (int i = 0; i < enemiesPerWave; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(spawnInterval);
            }

            yield return new WaitForSeconds(waveInterval);
        }
    }

    void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        enemy.GetComponent<Enemy>().waypoints = waypoints;
    }
}
