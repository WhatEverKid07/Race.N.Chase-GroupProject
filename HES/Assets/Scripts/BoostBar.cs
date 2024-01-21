using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoostBar : MonoBehaviour
{
    public Slider boostSlider;

    public void SetMaxBoost(int boost)
    {
        boostSlider.maxValue = boost;
        boostSlider.value = boost;
    }

    public void SetBoost(int boost)
    {
        boostSlider.value = boost;
    }
}
