using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Character;
using Assets.Scripts.Weapon;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [Header("Shops")]
    public GameObject WeaponShop;
    public GameObject BufShop;
    [Header("Weapons price")]
    public Text CrossbowPrice;
    public Text RiflePrice;
    [Header("Bufs price")] 
    public Text CrossbowDamagePrice;
    public Text CrossbowRatePrice;
    public Text RifleDamagePrice;
    public Text RifleRatePrice;

    // Start is called before the first frame update
    void Start()
    {
        CrossbowPrice.text = Help_Script.Weapons[1] ? "Bought" : Help_Script.CrossbowPrice.ToString();
        RiflePrice.text = Help_Script.Weapons[2] ? "Bought" : Help_Script.RiflePrice.ToString();

        CrossbowDamagePrice.text = Help_Script.CrossbowDamagePrice.ToString();
        CrossbowRatePrice.text = Help_Script.CrossbowRatePrice.ToString();
        RifleDamagePrice.text = Help_Script.RifleDamagePrice.ToString();
        RifleRatePrice.text = Help_Script.RifleRatePrice.ToString();

        if (Help_Script.Weapons[1] && Help_Script.Weapons[2])
        {
            WeaponShop.SetActive(!WeaponShop.activeInHierarchy);
            BufShop.SetActive(!BufShop.activeInHierarchy);
        }
    }

    public void ShopClick(int n)
    {
        switch (n)
        {
            case 0:
                WeaponShop.SetActive(!WeaponShop.activeInHierarchy);
                BufShop.SetActive(!BufShop.activeInHierarchy);
                break;

            case 1:
                if (!Help_Script.Weapons[1] && Help_Script.CrossbowPrice <= Help_Script.Money)
                {
                    Help_Script.Weapons[1] = true;
                    Help_Script.Money -= Help_Script.CrossbowPrice;
                    CrossbowPrice.text = "Bought";
                }
                break;

            case 2:
                if (!Help_Script.Weapons[2] && Help_Script.RiflePrice <= Help_Script.Money)
                {
                    Help_Script.Weapons[2] = true;
                    Help_Script.Money -= Help_Script.RiflePrice;
                    RiflePrice.text = "Bought";
                }
                break;

            case 3:
                if (Help_Script.CrossbowDamagePrice <= Help_Script.Money)
                {
                    Help_Script.Money -= Help_Script.CrossbowDamagePrice;
                    Help_Script.CrossbowDamagePrice = (int)(Help_Script.CrossbowRatePrice * Math.E);
                    CrossbowDamagePrice.text = Help_Script.CrossbowDamagePrice.ToString();
                    Help_Script.DamageMultipliers[1] += 0.3f;
                }
                break;

            case 4:
                if (Help_Script.CrossbowRatePrice <= Help_Script.Money)
                {
                    Help_Script.Money -= Help_Script.CrossbowRatePrice;
                    Help_Script.CrossbowRatePrice = (int)(Help_Script.CrossbowRatePrice * Math.E);
                    CrossbowRatePrice.text = Help_Script.CrossbowRatePrice.ToString();
                    Crossbow.shootDelay -= 0.05f;
                }
                break;

            case 5:
                if (Help_Script.RifleDamagePrice <= Help_Script.Money)
                {
                    Help_Script.Money -= Help_Script.RifleDamagePrice;
                    Help_Script.RifleDamagePrice = (int)(Help_Script.CrossbowRatePrice * Math.E);
                    RifleDamagePrice.text = Help_Script.RifleDamagePrice.ToString();
                    Help_Script.DamageMultipliers[2] += 0.3f;
                }
                break;

            case 6:
                if (Help_Script.RifleRatePrice <= Help_Script.Money)
                {
                    Help_Script.Money -= Help_Script.RifleRatePrice;
                    Help_Script.RifleRatePrice = (int)(Help_Script.CrossbowRatePrice * Math.E);
                    RifleRatePrice.text = Help_Script.RifleRatePrice.ToString();
                    Rifle.shootDelay -= 0.05f;
                }
                break;
        }
    }
}