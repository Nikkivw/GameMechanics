using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private Text magazineSizeText;
    [SerializeField] private Text storedAmmoText;

    public void UpdateInfo(Sprite WeaponIcon, int magazineSize, int storedAmmo)
    {
        icon.sprite = WeaponIcon;  
        magazineSizeText.text = magazineSize.ToString();
        storedAmmoText.text = storedAmmo.ToString();
    }
}
