using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private UnityEvent<int> ChangedHelth;

    private int _currentHealth;
    private int _minHealth;

    public int MaxHealth => _maxHealth;

    private void Start()
    {
        _minHealth = 0;
        _currentHealth = _maxHealth;
    }

    public void TakeAttack(int damage)
    {
        if (_currentHealth - damage <= _minHealth)
        {
            _currentHealth = _minHealth;
        }
        else
        {
            _currentHealth -= damage;
        }

        ChangedHelth.Invoke(_currentHealth);
    }

    public void Heal(int health)
    {
        if ((_currentHealth + health) <= _maxHealth)
        {
            _currentHealth += health;
            ChangedHelth.Invoke(_currentHealth);
        }
    }
}