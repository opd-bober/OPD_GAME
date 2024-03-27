using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public abstract class Enemy : MonoBehaviour
{
    protected Health healthComponent;
    protected int _speed;

    // Вместо конструктора используем метод Awake для инициализации
    protected virtual void Awake()
    {
        healthComponent = GetComponent<Health>();
        if (healthComponent == null)
        {
            Debug.LogError("Health component is not attached to the enemy");
        }

        // Подписываемся на событие смерти
        healthComponent.Killed += OnKilled;
    }
    
    public event Action OnDestroyEvent;
    // Деструктор для отписки от события
    private void OnDestroy()
    {
        if (healthComponent != null)
        {
            healthComponent.Killed -= OnKilled;
        }
    }

    // Абстрактный метод для обработки получения урона
    public void TakeDamage(int damage)
    {
        healthComponent.MinusHealth(damage);
    }

    // Абстрактный метод для обработки смерти врага
    protected abstract void OnKilled();
}
