using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    [SerializeField] private Transform WeaponHolderR = null;

    private Animator anim;
    private Inventory inventory;

    private void Start()
    {
        GetReferences();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // if AR is equipped.. play AR animations
            SetWeaponAnimations(0, WeaponType.AR);

            // if Shotgun is equipped.. play shotgun animations
            SetWeaponAnimations(0, WeaponType.Shotgun);

            // If Sniper is equipped.. play sniper animations
            SetWeaponAnimations(0, WeaponType.Sniper);

            EquipWeapon(inventory.GetItem(0).prefab, 0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            // if Pistol is equipped.. play pistol animations
            SetWeaponAnimations(1, WeaponType.pistol);

            EquipWeapon(inventory.GetItem(1).prefab, 1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            // if Melee is equipped.. play Melee animations
            SetWeaponAnimations(2, WeaponType.Melee);

            EquipWeapon(inventory.GetItem(2).prefab, 2);
        }
    }

    private void SetWeaponAnimations(int weaponStyle, WeaponType weaponType)
    {
        Weapon weapon = inventory.GetItem(weaponStyle);
        if (weapon != null)
        {
            if (weapon.weaponType == weaponType)
            {
                anim.SetInteger("WeaponType", (int)weaponType);
            }
        }
    }

    private void EquipWeapon(GameObject WeaponObject, int weaponStyle)
    {
        Weapon weapon = inventory.GetItem(weaponStyle);
        if(weapon != null)
        {
            Instantiate(WeaponObject, WeaponHolderR);
        }
    }

    private void GetReferences()
    {
        anim = GetComponentInChildren<Animator>();
        inventory = GetComponent<Inventory>();
    }
}
