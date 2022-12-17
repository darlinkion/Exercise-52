using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private HealthBar _healthBar;

    private int _currentHealth;

    private void Start()
    {
        _healthBar.SetMaxHealth(_maxHealth);
        _currentHealth = _maxHealth;
    }

    public void TakeAttack(int damage)
    {
        _currentHealth -= damage;
        _healthBar.SetHealth(_currentHealth);
    }

    public void Heal(int health)
    {
        if ((_currentHealth + health) <= _maxHealth)
        {
            _currentHealth += health;
            _healthBar.SetHealth(_currentHealth);

        }
    }
}