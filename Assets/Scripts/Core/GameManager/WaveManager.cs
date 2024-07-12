using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public int numEnemiesLeft;
    public Wave wave;
    public LevelManager levelManager;
    [SerializeField] Enemy enemy;

    private void Start()
    {
        if(wave.isComplete) { return; }
        SpawnWave();
    }

    private void SpawnWave()
    {
        //spawn the adequate number of Enemies per enemytype
        foreach (WaveEnemies waveEnemy in wave.waveEnemies)
        {
            for (int i = 0; i < waveEnemy.numEnemies; i++)
            {
                EnemyType type = enemy.GetEnemyOfClass(waveEnemy.enemyClass);
                Vector3 spawnPos = EnemySpawnPos(wave.spawnPosition, wave.spawnRange);
                GameObject newEnemy = Instantiate( type.prefab, spawnPos, Quaternion.identity);
                newEnemy.GetComponent<Health>().SetWaveManager(this);
                numEnemiesLeft++;
            }
        }
        if(numEnemiesLeft < wave.enemiesTotal) { Debug.Log("waveSpawn could not be completed."); }
        else { Debug.Log("wave spawned successfully"); }
    }

    public bool SetWave(Wave newWave)
    {
        wave = newWave;
        return true;
    }

    public void RemoveDeadEnemy()
    {
        numEnemiesLeft--;
        if (numEnemiesLeft <= 0)
        {
            wave.isComplete = true;
            levelManager.level.MarkWaveComplete(wave.id);
        }
    }

    private Vector3 EnemySpawnPos(Vector3 pos, float range)
    {
        Vector3 spawnPos = new Vector3();
        spawnPos.x = pos.x + Random.Range(-range, range);
        spawnPos.z = pos.z + Random.Range(-range, range);
        return spawnPos;
    }
}

[System.Serializable]
public struct Wave
{
    public int id;
    public int enemiesTotal;
    public List<WaveEnemies> waveEnemies;
    public Vector3 spawnPosition;
    public float spawnRange;
    public bool isComplete;
}

[System.Serializable]
public struct WaveEnemies
{
    public EnemyClass enemyClass;
    public int numEnemies;
}