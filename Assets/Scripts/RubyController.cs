using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RubyController : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    private InputAction moveAction;
    public float moveSpeed = 3f;
    public int maxHealth = 5;
    public int health { get { return currentHealth; }}
    int currentHealth = 1;

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

    internal void ChangeHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }
}
