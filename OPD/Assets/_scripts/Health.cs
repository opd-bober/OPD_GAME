using System;
using UnityEngine;

public class Health : MonoBehaviour, IHealth
{
    public static event Action<Health> Spawned;
    public event Action HealthChanged;
    public event Action Killed;


    public int currentHealth { get; set; }
    public int maxHealth { get; set; }

    private void Start()
    {
        Spawned?.Invoke(this);
        maxHealth = 100;
        currentHealth = maxHealth;
    }

    public void PlusHealth(int health)
    {
        if (currentHealth + health >= maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += health;
        }
        HealthChanged?.Invoke();
    }

    public void MinusHealth(int health)
    {

        if (currentHealth - health <= 0)
        {
            currentHealth = 0;
            Kill();
        }
        else
        {
            currentHealth -= health;
        }
        HealthChanged?.Invoke();
    }

    public void Kill()
    {
        Killed?.Invoke();
        Destroy(gameObject);
    }
}