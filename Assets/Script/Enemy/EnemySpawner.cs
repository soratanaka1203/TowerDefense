using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;   // 敵のプレハブ
    public Transform spawnPoint;     // 敵の出現位置
    [SerializeField] private Transform[] waypoints;//敵の経由地

    public int enemiesPerWave = 5;   // 1Waveあたりの敵数
    public float spawnInterval = 1f; // 敵同士の間隔（秒）
    public float waveInterval = 60f;  // Waveの間の待ち時間（秒）

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
