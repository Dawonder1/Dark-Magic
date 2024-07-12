using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    float attackRange;
    float attackRate;
    float attackTimer;
    float visionRange;
    float speed;
    Damage damage;
    [SerializeField] EnemyStats enemyStats;
    Transform player;
    Animator animator;
    Rigidbody rb;
    private void Start()
    {
        LoadStats();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        transform.LookAt(player);
    }

    private void Update()
    {
        float distanceFromPlayer = Vector3.Distance(transform.position, player.position);
        bool isInAttackRange =  distanceFromPlayer <= attackRange;
        bool isInVisionRange = distanceFromPlayer <= visionRange;

        //enemy movement and rotation;
        animator.SetFloat("speed", rb.linearVelocity.magnitude);
        if (player == null || !isInVisionRange) return;
        transform.LookAt(player);
        rb.linearVelocity = transform.forward * speed;

        if(!isInAttackRange) { return; }

        //enemy attack
        if(attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
            return;
        }
        animator.SetTrigger("attack");
        attackTimer = attackRate;
    }

    //animation event
    private void AttackPlayer()
    {
        //don't damage the player if the player has left attack range
        if (Vector3.Distance(player.position, transform.position) > attackRange) return;
        player.GetComponent<Health>().TakeDamage(damage);
    }

    private void LoadStats()
    {
        if (enemyStats == null) { Debug.Log("emptyStats"); return; }
        attackRate = enemyStats.stats.attackRate;
        attackTimer = attackRate;
        attackRange = enemyStats.stats.attackRange;
        visionRange = enemyStats.stats.visionRange;
        damage = enemyStats.stats.enemyDamage;
        speed = enemyStats.stats.speed;
        Debug.Log("enemy stats loaded");
    }
}
