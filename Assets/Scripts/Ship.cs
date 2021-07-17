using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f;
    [SerializeField] private float _currentHealth;
    [SerializeField] private float _damageValue = 10f;
    [SerializeField] private float _healValue = 10f;
    private bool _isHealthChanged;

    public float MaxHealth => _maxHealth;

    public delegate void HealthValueChanged(float currentHealth);
    public event HealthValueChanged NewValueApplied;

    public void IncreaseHealth()
    {
        _isHealthChanged = true;

        if (_isHealthChanged && _currentHealth < _maxHealth)
            ChangeHealthValue(_healValue);

        if (_currentHealth >= _maxHealth)
            _currentHealth = _maxHealth;
    }

    public void GetDamage()
    {
        _isHealthChanged = true;

        if (_isHealthChanged && _currentHealth > 0)
            ChangeHealthValue(-_damageValue);

        if (_currentHealth <= 0)
            _currentHealth = 0f;
    }
    
    private void Start()
    {
        _currentHealth = _maxHealth;
    }
    private void ChangeHealthValue(float valueToChange)
    {
        _currentHealth += valueToChange;
        NewValueApplied?.Invoke(_currentHealth);
        _isHealthChanged = false;
    }
}