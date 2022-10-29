using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int currentHealth;
    [SerializeField] Slider healhBar;
    private void Start()
    {
        healhBar.value = currentHealth;
    }
    public int GetCurrentHealth()
    {
        healhBar.value = currentHealth;
        return currentHealth;
    }
    public void IncreaseCurrentHealth(int increaseHealth)
    {
        currentHealth += increaseHealth;
        GetCurrentHealth();
    }
    public void ReduceCurrentHealth(int reduceHealth)
    {
        currentHealth -= reduceHealth;
        GetCurrentHealth();
    }


}
