using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Character;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Text CrossbowPrice, RiflePrice;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        CrossbowPrice.text = Help_Script.CrossbowPrice.ToString();
        RiflePrice.text = Help_Script.RiflePrice.ToString();

        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ShopClick(int n)
    {
        switch (n)
        {
            case 0:
                // TODO: Click replace button
                break;

            case 1:
                if (Help_Script.CrossbowPrice <= Help_Script.Money)
                {
                    Help_Script.Weapons[1] = true;
                }
                break;

            case 2:
                if (Help_Script.RiflePrice <= Help_Script.Money)
                {
                    Help_Script.Weapons[2] = true;
                }
                break;
        }
    }
}