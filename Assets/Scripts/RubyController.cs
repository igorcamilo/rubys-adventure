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
    int currentHealth;

    public float timeInvincible = 2.0f;
    bool isInvincible;
    float invincibleTimer;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        var input = GetComponent<PlayerInput>();
        moveAction = input.actions.FindAction("Move");
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = rigidbody.position;
        position += moveSpeed * Time.deltaTime * moveAction.ReadValue<Vector2>();
        rigidbody.MovePosition(position);

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }
    }

    internal void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
                return;
            
            isInvincible = true;
            invincibleTimer = timeInvincible;
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }
}
