using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    private const int minValue = 0, maxValue = 100;
    
    public int Health
    {
        get { return (int)this.slider.value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.slider.maxValue = maxValue;
        this.slider.minValue = minValue;
        this.slider.wholeNumbers = true;

        this.slider.value = maxValue;
    }

    public void TakeDamage(int damage)
    {
        this.slider.value -= damage;
    }

    public void ResetHealth()
    {
        this.slider.value = maxValue;
    }
}
