using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject orbPrefab;
    [SerializeField] Transform orbSpawnTransform;
    [SerializeField] PlayerStats stats;
    private Transform target;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Attack()
    {
        target = null;
        if (orbPrefab == null) return;

        //check for nearby enemies
        Vector3 rangeScanPos = transform.position + ((stats.playerStats.attackRange / 2 ) * transform.forward );
        //Collider[] colliders = Physics.OverlapSphere(rangeScanPos, attackRange);
        Collider[] colliders = Physics.OverlapBox(rangeScanPos, new Vector3(0.5f, 0.5f, stats.playerStats.attackRange /2));
        Debug.DrawLine(transform.position, transform.forward * stats.playerStats.attackRange, Color.red);


        //determine which enemy to target
        foreach(Collider collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                target = collider.transform;
                break;
            }
        }

        //attack selected enemy target
        if(target == null) { Debug.Log("No Enemies Found");  return; }
        animator.SetTrigger("attack");
    }


    //animation event
    public void SpawnOrb()
    {
        //Vector3 orbSpawnPos = transform.position + transform.forward + transform.up;
        GameObject orb = Instantiate(orbPrefab, orbSpawnTransform.position, Quaternion.identity);
        orb.GetComponent<Orb>().SetTarget(target);
        orb.GetComponent<Orb>().damage = stats.playerStats.damage;
    }
}
