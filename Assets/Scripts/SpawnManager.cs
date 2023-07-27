using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private GameObject powerUpPrefab;
    private float spawnRange = 9f;
    private int currentEnemies;
    private int wave = 1;

    void Start()
    {
        SpawnEnemyWave(wave);
    }

    public void RemoveEnemy()
    {
        currentEnemies--;
        if (currentEnemies == 0)
        {
            wave++;
            SpawnEnemyWave(wave);
        }
    }

    private void SpawnEnemyWave(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject enemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
            Instantiate(enemy, GenerateSpawnPoint(), enemy.transform.rotation);
            currentEnemies++;
        }
        Instantiate(powerUpPrefab, GenerateSpawnPoint(), powerUpPrefab.transform.rotation);
    }
    
    private Vector3 GenerateSpawnPoint()
    {
        var spawnX = Random.Range(-spawnRange, spawnRange);
        var spawnZ = Random.Range(-spawnRange, spawnRange);
        return new Vector3(spawnX, 0, spawnZ);
    }
}
