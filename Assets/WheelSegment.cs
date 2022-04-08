using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class WheelSegment : MonoBehaviour
{
    public int id;
    public Image segmentIcon;
    public TMP_Text upgradeName;
    public void Start()
    {
        if (id < ShopManager.instance.gunUpgrades.Length)
        {
            segmentIcon.sprite = ShopManager.instance.gunUpgrades[id].icon;
            upgradeName.text = ShopManager.instance.gunUpgrades[id].name;
        }
    }
}
