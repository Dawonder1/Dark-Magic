using System.Collections.Generic;
using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Scriptable Objects/Level")]
public class Level : ScriptableObject
{
    public int level;
    public List<Wave> waves;
    private string saveWavePath;

    private void OnEnable()
    {
        saveWavePath = Application.persistentDataPath + "/saveWavesLevel" + level.ToString();
    }

    public void MarkWaveComplete(int waveid)
    {
        for( int i = 0; i < waves.Count; i++)
        {
            if (waves[i].id != waveid) { continue; }
            Wave wave = waves[i];
            wave.isComplete = true;
            waves[i] = wave;
        }
    }

    private void LoadWaves()
    {
        if(!File.Exists(saveWavePath)) { return; }
        string str = File.ReadAllText(saveWavePath);
        waves = JsonUtility.FromJson<List<Wave>>(str);
    }

    private void SaveWaves()
    {
        string str = JsonUtility.ToJson(waves);
        File.WriteAllText(saveWavePath, str);
    }

    private void OnDisable()
    {
        //saveWaves();
    }
}