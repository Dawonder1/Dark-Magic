using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Scriptable Objects/Enemy")]
public class Enemy : ScriptableObject
{
    public List<EnemyType> enemyTypes;

    public EnemyType GetEnemyOfClass(EnemyClass enemyClass)
    {
        foreach (EnemyType enemy in enemyTypes)
        {
            if (enemy.enemyClass == enemyClass) { return enemy; }
        }
        throw new System.Exception("enemyClass is not valid!");
    }
}

[System.Serializable]
public struct EnemyType
{
    public int id;
    public EnemyClass enemyClass;
    public EnemyStats stats;
    public GameObject prefab;
}

[System.Serializable]
public enum EnemyClass
{
    spider,
    Boss1
}