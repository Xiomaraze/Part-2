using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider hpBar;

    public void TakeDamage(float damage)
    {
        hpBar.value -= damage;
    }
}
