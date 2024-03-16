using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;
    private RectTransform _healthView;
    private Health _health;
    private Canvas _canvas;
    private Image _image;

    private void Start()
    {
        _healthView = GetComponent<RectTransform>();
        _canvas = GetComponentInParent<Canvas>();
        _image = GetComponent<Image>();
        _image.enabled = false;
    }
    public void ConnectHealth(Health health)
    {
        _health = health;
        _health.HealthChanged += DisplayHealth;
        _health.Killed += Remove;
    }

    private void Update()
    {
        Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, _health.gameObject.transform.position + _offset);

        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvas.transform as RectTransform, screenPoint, _canvas.worldCamera, out localPoint);

        _healthView.localPosition = localPoint;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= DisplayHealth;
        _health.Killed -= Remove;
    }
    private void DisplayHealth()
    {
        if(_image.enabled == false)
        {
            _image.enabled = true;
        }
        float currentHealth = _health.currentHealth;
        float maxHealth = _health.maxHealth;

        float healthPercentage = currentHealth / maxHealth;
        _healthView.localScale = new Vector3(healthPercentage, 1, 1);
    }

    private void Remove()
    {
        Destroy(gameObject);
    }
}