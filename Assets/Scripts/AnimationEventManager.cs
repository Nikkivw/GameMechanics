using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventManager : MonoBehaviour
{
    private Inventory inventory;
    private EquipmentManager manager;

    private void Start()
    {
        GetReferences();
    }

    public void DestroyWeapon()
    {
        //Destroy(manager.currentWeaponObject);
    }

    public void InstantiateWeapon()
    {
        if (manager == null)
            //manager.currentWeaponObject = Instantiate(inventory.GetItem(manager.currentlyEquippedWeapon).prefab, manager.WeaponHolderR);
            manager.currentWeaponBarrel = manager.currentWeaponObject.transform.GetChild(0);
    }

    private void GetReferences()
    {
        inventory = GetComponentInParent<Inventory>();
        manager = GetComponentInParent<EquipmentManager>();
    }
}
