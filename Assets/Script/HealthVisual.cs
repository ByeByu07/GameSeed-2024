using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthVisual : MonoBehaviour
{
    [SerializeField] Health health;
    [SerializeField] Image imageBar;

    private void Start()
    {
        health.OnHitEH += Health_OnHitEH;
    }

    private void Health_OnHitEH(object sender, Health.OnHitEventHandler e)
    {
        Debug.Log(e.restHealth);
        imageBar.fillAmount = e.restHealth;
    }
}
