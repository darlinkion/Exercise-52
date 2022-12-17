using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[RequireComponent(typeof(HealthBar))]

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private HealthBar _healthBar;

    private int _currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        _healthBar.SetMaxHealth(_maxHealth);
        _currentHealth = _maxHealth;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        
    }

    public void TakeAttack(int damage)
    {
        _currentHealth -= damage;
        _healthBar.SetHealth(_currentHealth);

    }

    public void Heal(int health)
    {
        if((_currentHealth+health) <=_maxHealth)
        {
            _currentHealth += health;
            _healthBar.SetHealth(_currentHealth);
            
        }
    }
}
