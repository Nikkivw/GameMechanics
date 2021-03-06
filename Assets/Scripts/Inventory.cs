using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //0 = primary, 1 = secondary, 2 = melee
    [SerializeField] private Weapon[] weapons;

    private WeaponShooting shooting;

    public Weapon testweapon;
    public Weapon testweapon2;

    private void Start()
    {
        Getreferences();
        InitVariables();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            AddItem(testweapon);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            AddItem(testweapon2);
        }
    }

    public void AddItem(Weapon newItem)
    {
        int newItemIndex = (int)newItem.weaponStyle;

        if (weapons[newItemIndex] != null)
        {
            RemoveItem(newItemIndex);
        }
        weapons[newItemIndex] = newItem;

        shooting.InitAmmo((int)newItem.weaponStyle, newItem);
    }

    public void RemoveItem(int index)
    {
        weapons[index] = null;
    }

    public Weapon GetItem(int index)
    {
        return weapons[index];
    }

    private void InitVariables()
    {
        weapons = new Weapon[3];
    }

    private void Getreferences()
    {
        shooting = GetComponent<WeaponShooting>();
    }
}