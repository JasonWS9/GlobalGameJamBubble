using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class MyHealthBar : MonoBehaviour
{
  public Slider slider;

  public void SetHealth(int health)
  {
    slider.value = health;
  }

  public void SetMaxHealth(int health)
  {
    slider.maxValue = health;
    slider.value = health;

  }
  
  
  
}
