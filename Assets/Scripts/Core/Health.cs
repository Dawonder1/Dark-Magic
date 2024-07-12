using UnityEngine;

public class Health : MonoBehaviour
{
    int health;
    public EnemyStats enemyStats;
    public PlayerStats playerStats;
    public WaveManager waveManager;
    private delegate void OnEnemyDied();
    event OnEnemyDied OnEnemyKilled;

    private void Start()
    {
        //if gameobject is an enemy
        if(CompareTag("Enemy")) health = enemyStats.stats.maxHealth;
        if(CompareTag("Player")) health = playerStats.playerStats.maxHealth;
    }

    public void SetWaveManager(WaveManager manager)
    {
        waveManager = manager;
        OnEnemyKilled += waveManager.RemoveDeadEnemy;
    }


    public void TakeDamage(Damage damage)
    {
        health -= damage.value;
        if(health <= 0)
        {
            Destroy(gameObject);
            if (TryGetComponent<PlayerMovement>(out PlayerMovement player))
            {
                //gameOver();
                return;
            }
            OnEnemyKilled();
        }
    }
}