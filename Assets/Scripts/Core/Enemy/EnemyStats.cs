using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "Scriptable Objects/EnemyStats")]
public class EnemyStats : ScriptableObject
{
    public EnemyStatistics stats;
}

[System.Serializable]
public struct EnemyStatistics
{
    public float attackRate;
    public float attackRange;
    public float speed;
    public float visionRange;
    public Damage enemyDamage;
    public int maxHealth;
}
