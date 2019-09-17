using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RubyController : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private InputAction moveAction;
    public float moveSpeed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        var input = GetComponent<PlayerInput>();
        moveAction = input.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = rigidbody.position;
        position += moveSpeed * Time.deltaTime * moveAction.ReadValue<Vector2>();
        rigidbody.MovePosition(position);
    }
}
