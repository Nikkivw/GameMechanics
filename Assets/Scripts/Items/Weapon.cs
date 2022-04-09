using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Weapon", menuName = "Items/Weapons")]

public class Weapon : Item
{
    public GameObject prefab;
    public GameObject MuzzelFlashParticles;
    public int magazineSize;
    public int storedAmmo;
    public float fireRate;
    public float range;
    public WeaponType weaponType;
    public WeaponStyle weaponStyle;
}

public enum WeaponType {Melee, pistol, AR, Shotgun, Sniper}
public enum WeaponStyle {Primary, Secondary, Melee}