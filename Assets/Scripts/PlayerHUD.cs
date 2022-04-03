using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] private ProgressBar healthBar;
    [SerializeField] private WeaponUI weaponUI;

    public void UpdateHealth(int currenthealth, int maxHealth)
    {
      healthBar.setValues(currenthealth, maxHealth);   
    }

    public void UpdateWeaponUI(Weapon newWeapon)
    {
        weaponUI.UpdateInfo(newWeapon.Icon, newWeapon.magazineSize, newWeapon.magazineCount);
    }
}   