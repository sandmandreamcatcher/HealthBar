using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f;
    [SerializeField] private float _currentHealth;
    [SerializeField] private float _damageValue = 10f;
    [SerializeField] private float _healValue = 10f;

    public float MaxHealth => _maxHealth;

    public delegate void HealthValueChanged(float currentHealth);
    public event HealthValueChanged NewValueApplied;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }
    
    private void ChangeHealthValue(float valueToChange)
    {
        _currentHealth += valueToChange;
        NewValueApplied?.Invoke(_currentHealth);
    }
    
    private void IncreaseHealth()
    {
        if (_currentHealth < _maxHealth)
            ChangeHealthValue(_healValue);

        if (_currentHealth >= _maxHealth)
            _currentHealth = _maxHealth;
    }

    private void GetDamage()
    {
        if (_currentHealth > 0)
            ChangeHealthValue(-_damageValue);

        if (_currentHealth <= 0)
            _currentHealth = 0f;
    }
}