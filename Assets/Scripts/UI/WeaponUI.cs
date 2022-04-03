using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private Text magazineSizeText;
    [SerializeField] private Text magazineCountText;

    public void UpdateInfo(Sprite WeaponIcon, int magazineSize, int magazineCount)
    {
        icon.sprite = WeaponIcon;  
        magazineSizeText.text = magazineSize.ToString();
        int magzineCountAmount = magazineSize * magazineCount;
        magazineCountText.text = magzineCountAmount.ToString();
    }
}
