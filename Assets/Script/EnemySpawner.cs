using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;   // �G�̃v���n�u
    public Transform spawnPoint;     // �G�̏o���ʒu
    [SerializeField] private Transform[] waypoints;//�G�̌o�R�n

    public int enemiesPerWave = 5;   // 1Wave������̓G��
    public float spawnInterval = 1f; // �G���m�̊Ԋu�i�b�j
    public float waveInterval = 60f;  // Wave�̊Ԃ̑҂����ԁi�b�j

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
            Debug.Log("Wave " + currentWave + " �J�n�I");

            for (int i = 0; i < enemiesPerWave; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(spawnInterval);
            }

            Debug.Log("Wave " + currentWave + " �I���B����Wave�܂őҋ@...");
            yield return new WaitForSeconds(waveInterval);
        }
    }

    void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        enemy.GetComponent<Enemy>().waypoints = waypoints;
    }
}
