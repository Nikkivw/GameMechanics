using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    private PlayerHUD hud;
    private UIManager ui;

    private void Start()
    {
        GetReferences();
        InitVariables();
    }

    private void GetReferences()
    {
        hud = GetComponent<PlayerHUD>();
        ui = GetComponent<UIManager>();
    }

    public override void CheckHealth()
    {
        base.CheckHealth();
        hud.UpdateHealth(health, maxHealth);
    }

    public override void Death()
    {
        base.Death();
        ui.SetActiveHud(false);
    }

    private void Update()
    {
        //Test if the Health bar works
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            Heal(20);
        }
    }
}
