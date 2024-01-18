using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int healthLose;

    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    //void Update()
   // {
    //    if(Input.GetKeyDown(KeyCode.Space))
    //    {
    //        TakeDamage(healthLose);
    //    }
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Object"))
        {
            TakeDamage(healthLose);
            Debug.Log("Hit");
        }
    }

    void TakeDamage(int damaged)
    {
        currentHealth -= damaged;

        healthBar.SetHealth(currentHealth);
    }
}
