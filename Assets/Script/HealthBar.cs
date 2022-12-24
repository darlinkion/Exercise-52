using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Gradient _gradient;
    [SerializeField] private Image _fill;
    [SerializeField] private Player _player;

    private WaitForFixedUpdate _waitForFixedUpdate;
    private float _deltaHealth;
    
    public void SetHealth(int health)
    {
        StopCoroutine(MoveScale(health));
        StartCoroutine(MoveScale(health));
    }

    private void Start()
    {
        _slider.maxValue = _player.MaxHealth;
        _slider.value = _player.MaxHealth;
        _waitForFixedUpdate = new WaitForFixedUpdate();
        _deltaHealth = 1f;

        _gradient.Evaluate(_slider.normalizedValue);
    }

    private IEnumerator MoveScale(int health)
    {
        while (_slider.value != health)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, health, _deltaHealth);
            _fill.color = _gradient.Evaluate(_slider.normalizedValue);

            yield return _waitForFixedUpdate;
        }
    }
}