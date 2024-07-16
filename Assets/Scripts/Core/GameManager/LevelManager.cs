using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Level level;
    [SerializeField] GameObject waveManagerPrefab;
    private List<WaveManager> waveManagers;

    private void Start()
    {
        waveManagers = new List<WaveManager>();
        SpawnLevelWaves();
    }

    void SpawnLevelWaves()
    {
        foreach(Wave wave in level.waves)
        {
            GameObject WM = Instantiate(waveManagerPrefab);
            WaveManager waveManager = WM.GetComponent<WaveManager>();
            waveManagers.Add(waveManager);
            waveManager.SetWave(wave);
            waveManager.levelManager = this;
        }
    }
}
