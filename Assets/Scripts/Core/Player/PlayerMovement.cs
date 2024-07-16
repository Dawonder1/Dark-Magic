using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float MovementX;
    private float MovementY;
    private float rotateAngle;
    [SerializeField] private float speed;
    Rigidbody rb;
    Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    private void OnMove(InputValue movementValue)
    {
        Vector2 movementDir = movementValue.Get<Vector2>();
        MovementX = movementDir.x;
        MovementY = movementDir.y;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(MovementX, 0, MovementY);
        rb.linearVelocity = movement * speed;

        Debug.Log(movement);

        if(movement == null) return;
        rotateAngle = Vector3.Angle(transform.up, movement);
        transform.Rotate(Vector3.up, rotateAngle);
        transform.LookAt(transform.position + movement);

        animator.SetFloat("speed", rb.linearVelocity.magnitude);
    }
}