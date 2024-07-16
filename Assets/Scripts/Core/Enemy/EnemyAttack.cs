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
        attackRate = enemyStats.stats.attackRate;
        attackTimer = attackRate;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        transform.LookAt(player);
    }

    private void Update()
    {
        float distanceFromPlayer = Vector3.Distance(transform.position, player.position);
        bool isInAttackRange =  distanceFromPlayer <= enemyStats.stats.attackRange;
        bool isInVisionRange = distanceFromPlayer <= enemyStats.stats.visionRange;

        //enemy movement and rotation;
        animator.SetFloat("speed", rb.linearVelocity.magnitude);
        if (player == null || !isInVisionRange) return;
        transform.LookAt(player);
        rb.linearVelocity = transform.forward * enemyStats.stats.speed;

        if(!isInAttackRange) { return; }

        //enemy attack
        if(attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
            return;
        }
        animator.SetTrigger("attack");
        attackTimer = enemyStats.stats.attackRate;
    }

    //animation event
    private void AttackPlayer()
    {
        //don't damage the player if the player has left attack range
        if (Vector3.Distance(player.position, transform.position) > attackRange) return;
        player.GetComponent<Health>().TakeDamage(enemyStats.stats.enemyDamage);
    }

    private void LoadStats()
    {
        if (enemyStats == null) { Debug.Log("emptyStats"); return; }
    }
}
