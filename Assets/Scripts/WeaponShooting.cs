using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShooting : MonoBehaviour
{
    private float lastShootTime = 0;

    [SerializeField] private bool canShoot = true;

    [SerializeField] private int primaryCurrentAmmo;
    [SerializeField] private int primaryCurrentAmmoStorage;

    [SerializeField] private int secondaryCurrentAmmo;
    [SerializeField] public int secondaryCurrentAmmoStorage;

    [SerializeField] private bool primaryMagazineIsEmpty = false;
    [SerializeField] private bool secondaryMagazineIsEmpty = false;

    private Camera cam;
    private Inventory inventory;
    private EquipmentManager manager;
    private PlayerHUD hud;
    private PlayerStats stats;  

    private void Start()
    {
        GetReferences();
        canShoot = true;
    }

    private void Update()
    {
        if (!stats.IsDead())
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                Shoot();
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                Reload(manager.currentlyEquippedWeapon);
            }
        }
    }

    private void RaycastShoot(Weapon currentWeapon)
    {
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2,Screen.height / 2));
        RaycastHit hit;

        float currentWeaponRange = currentWeapon.range;

        if (Physics.Raycast(ray, out hit, currentWeaponRange))
        {
            Debug.Log(hit.transform.name);
        }

        Instantiate(currentWeapon.MuzzelFlashParticles, manager.currentWeaponBarrel);
    }

    private void Shoot()
    {
        CheckCanShoot(manager.currentlyEquippedWeapon);

        if (canShoot)
        {
            Weapon currentWeapon = inventory.GetItem(manager.currentlyEquippedWeapon);

            if (Time.time > lastShootTime + currentWeapon.fireRate)
            {
                Debug.Log("Shoot");
                lastShootTime = Time.time;

                RaycastShoot(currentWeapon);
                UseAmmo((int)currentWeapon.weaponStyle, 1, 0);
            }
        }
        else
            Debug.Log("not enough ammo in magazine");
    }

    private void UseAmmo(int slot, int currentAmmoUsed, int currentStoredAmmoUsed)
    {
        //primary
        if (slot == 0)
        {
            if(primaryCurrentAmmo <= 0)
            {
                primaryMagazineIsEmpty = true;
                CheckCanShoot(manager.currentlyEquippedWeapon);
            }
            else
            {
                primaryCurrentAmmo -= currentAmmoUsed;
                primaryCurrentAmmoStorage -= currentStoredAmmoUsed;
                hud.UpdateWeaponAmmoUI(primaryCurrentAmmo, primaryCurrentAmmoStorage);
            }
        }

        //secondary
        if (slot == 1)
        {
            secondaryMagazineIsEmpty = true;
            CheckCanShoot(manager.currentlyEquippedWeapon);
        }
        else
        {
            secondaryCurrentAmmo -= currentAmmoUsed;
            secondaryCurrentAmmoStorage -= currentStoredAmmoUsed;
            hud.UpdateWeaponAmmoUI(secondaryCurrentAmmo, secondaryCurrentAmmoStorage);
        }
    }

    private void AddAmmo(int slot, int currentAmmoAdded, int currentStoredAmmoAdded)
    {
        //primary
        if (slot == 0)
        {
            
            primaryCurrentAmmo += currentAmmoAdded;
            primaryCurrentAmmoStorage += currentStoredAmmoAdded;
            hud.UpdateWeaponAmmoUI(primaryCurrentAmmo, primaryCurrentAmmoStorage);
        }

        //secondary
        if (slot == 1)
        {
            secondaryCurrentAmmo += currentAmmoAdded;
            secondaryCurrentAmmoStorage += currentStoredAmmoAdded;
            hud.UpdateWeaponAmmoUI(secondaryCurrentAmmo, secondaryCurrentAmmoStorage);
        }
    }

    private void Reload(int slot)
    {
        //Primary
        if(slot == 0)
        {
            int ammoToReload = inventory.GetItem(0).magazineSize - primaryCurrentAmmo;

            // If enough ammo to reload magazine
            if (primaryCurrentAmmoStorage >= ammoToReload)
            {
                //if current magazine is full
                if (primaryCurrentAmmo == inventory.GetItem(0).magazineSize)
                {
                    Debug.Log("Magazine is already full.");
                    return;
                }

                AddAmmo(slot, ammoToReload, 0);
                UseAmmo(slot, 0, ammoToReload);

                primaryMagazineIsEmpty = false;
                CheckCanShoot(slot);
            }
            else
                Debug.Log("Not enough ammo to reload");
        }

        //secondary
        if(slot == 1)
        {
            int ammoToReload = inventory.GetItem(1).magazineSize - secondaryCurrentAmmo;

            // If enough ammo to reload magazine
            if (secondaryCurrentAmmoStorage >= ammoToReload)
            {
                //if current magazine is full
                if (secondaryCurrentAmmo == inventory.GetItem(1).magazineSize)
                {
                    Debug.Log("Magazine is already full.");
                    return;
                }

                AddAmmo(slot, ammoToReload, 0);
                UseAmmo(slot, 0, ammoToReload);

                secondaryMagazineIsEmpty = false;
                CheckCanShoot(slot);
            }
            else
                Debug.Log("Not enough ammo to reload");
        }
    }

    private void CheckCanShoot(int slot)
    {
        //Primary
        if (slot == 0)
        {
            if (primaryMagazineIsEmpty)
                canShoot = false;
            else
                canShoot = true;
        }

        //Secondary
        if (slot == 1)
        {
            if (secondaryMagazineIsEmpty)
                canShoot = false;
            else
                canShoot = true;
        }
    }

    public void InitAmmo(int slot, Weapon weapon)
    {
        //primary
        if (slot == 0)
        {
            primaryCurrentAmmo = weapon.magazineSize;
            primaryCurrentAmmoStorage = weapon.storedAmmo;
        }
       
        //secondary
        if (slot == 1)
        {
            secondaryCurrentAmmo = weapon.magazineSize;
            secondaryCurrentAmmoStorage = weapon.storedAmmo;
        }
    }

    private void GetReferences()
    {
        cam = GetComponentInChildren<Camera>();
        inventory = GetComponentInChildren<Inventory>();
        manager = GetComponent<EquipmentManager>();
        hud = GetComponent<PlayerHUD>();
        stats = GetComponent<PlayerStats>();
    }
}
