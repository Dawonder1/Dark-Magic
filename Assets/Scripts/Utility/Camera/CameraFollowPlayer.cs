using TMPro.Examples;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] Transform target;
    InputSystem_Actions inputActions;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputActions = new InputSystem_Actions();
        inputActions.Enable();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = target.position;

        Vector2 cameraLookDir = inputActions.Player.Look.ReadValue<Vector2>();
        if (cameraLookDir.magnitude < 10) return; 

        //Camera.main.transform.Rotate(0,cameraLookDir.x, 0);
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }
}
