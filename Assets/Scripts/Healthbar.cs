using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private float _animationTime = 10f;
    [SerializeField] private Slider _slider;
    [SerializeField] private Gradient _gradient;
    [SerializeField] private Image _fill;
    [SerializeField] private Ship _ship;
    private Coroutine _movingCoroutine;

    private void Start()
    {
        _fill.color = _gradient.Evaluate(_slider.normalizedValue);
        _slider.value = _ship.MaxHealth;
        _ship.NewValueApplied += OnNewValueApplied;
    }

    private void OnDestroy()
    {
        _ship.NewValueApplied -= OnNewValueApplied;
    }

    private void OnNewValueApplied(float valueToChange)
    {
        if (_movingCoroutine != null)
            StopCoroutine(_movingCoroutine);

        _movingCoroutine = StartCoroutine(ChangeProgressBarValue(valueToChange));
    }

    private IEnumerator ChangeProgressBarValue(float targetValue)
    {
        while (_slider.value != targetValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, targetValue, Time.deltaTime * _animationTime);
            yield return null;
        } 
    }

    private void ChangeGradientColor()
    {
        _fill.color = _gradient.Evaluate(_slider.normalizedValue);
    }
}