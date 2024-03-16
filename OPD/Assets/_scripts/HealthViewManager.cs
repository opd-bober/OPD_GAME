using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthViewManager : MonoBehaviour
{
    [SerializeField] private RectTransform healthBarPrefab;
    private Canvas canvas;


    private void Start()
    {
        canvas = GetComponent<Canvas>();
    }
    private void OnEnable()
    {
        Health.Spawned += HandleSpawned;
    }

    private void OnDisable()
    {
        Health.Spawned -= HandleSpawned;
    }

    private void HandleSpawned(Health health)
    {
        RectTransform healthBar = Instantiate(healthBarPrefab, canvas.transform);
        healthBar.GetComponent<HealthView>().ConnectHealth(health);
    }
}
