using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    float health;
    int maxHealth;
    [SerializeField] Slider healthBar;
    public EnemyStats enemyStats;
    public PlayerStats playerStats;
    public WaveManager waveManager;
    private delegate void OnEnemyDied();
    event OnEnemyDied OnEnemyKilled;

    private void Start()
    {
        //if gameobject is an enemy
        if(CompareTag("Enemy")) maxHealth = enemyStats.stats.maxHealth;
        if(CompareTag("Player")) maxHealth = playerStats.playerStats.maxHealth;
        health = maxHealth;
    }

    public void SetWaveManager(WaveManager manager)
    {
        waveManager = manager;
        OnEnemyKilled += waveManager.RemoveDeadEnemy;
    }


    public void TakeDamage(Damage damage)
    {
        health -= damage.value;
        UpdateHealthBar();
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

    private void UpdateHealthBar()
    {
        healthBar.value = health / maxHealth;
    }

    private void Stun()
    {
        GetComponent<Animator>().SetTrigger("stun");
    }
}