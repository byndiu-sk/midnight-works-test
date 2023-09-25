using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private CharacterStats characterStats;

    private void Awake()
    {
        characterStats.OnHealthChanged += CharacterStats_OnHealthChanged;
    }

    private void CharacterStats_OnHealthChanged(object sender, float e)
    {
        slider.value = e / characterStats.GetMaxHealth();
    }
}
