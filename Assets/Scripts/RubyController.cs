using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RubyController : MonoBehaviour
{
    private InputAction moveAction;
    public float moveSpeed = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        var input = GetComponent<PlayerInput>();
        moveAction = input.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        position += moveSpeed * moveAction.ReadValue<Vector2>();
        transform.position = position;
    }
}
