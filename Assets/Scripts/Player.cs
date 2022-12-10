using UnityEngine;
using System.Collections;
using System;
using TMPro;

// We need to make some assumptions about what direction the 
// character spawns in. Currenty assuming always spawns "down."

public class Player: MovingObject
{
    private float moveSpeed;
    private int health = 100;
    public TextMeshProUGUI healthUIText;
    private Vector3 localScale;
    public Animator animator;


    protected override void Start()
    {
        moveSpeed = 5f;
        updateHealthText();
        base.Start();
        localScale = transform.localScale;
    }

    protected override void Update()
    {
        base.Update();

        animator.SetFloat("Horizontal", velocity.x);
        animator.SetFloat("Vertical", velocity.y);
        animator.SetFloat("Speed", velocity.sqrMagnitude);  //might change

        if (velocity.x != 0 || velocity.y != 0)
        {
            animator.SetFloat("LastX", velocity.x);
            animator.SetFloat("LastY", velocity.y);
        }

        velocity.Normalize();
        velocity *= moveSpeed;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("OnCollisionEnter2D");
    }

    public void TakeDamage(int amount)
    {
      health -= amount;
      if (health < 0)
      {
        health = 0;
      }
      Debug.Log("Current health: " + health);
      updateHealthText();
    }

    void updateHealthText()
    {
      String healthStr = health.ToString();
      healthUIText.text = healthStr;//string.Format("{0}", health);
      Debug.Log(healthUIText.text);
    }
}