using UnityEngine;

public class Orb : MonoBehaviour
{
    [SerializeField] private float travelSpeed;
    private Transform target;
    public Damage damage;
    public void SetTarget(Transform targetTransform)
    {
        target = targetTransform;
        Invoke("Disappear", 5f);
    }

    private void Update()
    {
        if (target == null) return;
        Vector3 moveVector = Vector3.Lerp(transform.position, target.position, travelSpeed);
        transform.position = moveVector;
    }

    private void Disappear()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            other.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
