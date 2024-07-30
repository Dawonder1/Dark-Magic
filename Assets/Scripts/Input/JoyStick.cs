using UnityEngine;

public class JoyStick : MonoBehaviour
{
    Vector2 origin;
    public Vector2 MoveInput { get; private set; }
    public static JoyStick singleton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        origin = transform.position;
        if (singleton == null) singleton = this;
        else Destroy(this);
    }

    // Update is called once per frame
    void Update()
    {   
        Vector2 currentPosition = new Vector2 (transform.position.x, transform.position.y);
        Vector2 moveInput = (currentPosition - origin).normalized;
        MoveInput = moveInput;
    }
}
