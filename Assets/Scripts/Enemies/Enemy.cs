using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private float health = 100;
    //[SerializeField] private ProgressBar HealthBar;
    [SerializeField] private Slider healthBar;

    private float maxHealth;

    private void Awake()
    {
        maxHealth = health;
    }

    private void Update()
    {
        healthBar.value = health;
    }

    public void OnTakeDamage(float Damage)
    {
        health -= Damage;
        
        if (health < 0)
        {
            OnDied();
        }
    }

    private void OnDied()
    {
        //Destroy(gameObject);
        PoolManager.Despawn(gameObject);
    }
}

public enum EnemyState
{
    Idle,
    Move,
    Die
}
