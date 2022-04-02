using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] private ProgressBar healthBar;

    public void UpdateHealth(int currenthealth, int maxHealth)
    {
      healthBar.setValues(currenthealth, maxHealth);   
    }
}   