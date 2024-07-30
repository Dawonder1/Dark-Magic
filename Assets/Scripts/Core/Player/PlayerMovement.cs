using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float rotateAngle;
    [SerializeField] private float speed;
    Rigidbody rb;
    Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Vector3 //movement = new Vector3(MovementX, 0, MovementY);
        movement = new Vector3(JoyStick.singleton.MoveInput.x, 0, JoyStick.singleton.MoveInput.y);
        rb.linearVelocity = movement * speed;

        if(movement == null) return;
        rotateAngle = Vector3.Angle(transform.up, movement);
        transform.Rotate(Vector3.up, rotateAngle);
        transform.LookAt(transform.position + movement);

        animator.SetFloat("speed", rb.linearVelocity.magnitude);
    }
}