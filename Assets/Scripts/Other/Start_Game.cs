using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Start_Game : MonoBehaviour
{
    public GameObject[] GG; // Персонажи
    public GameObject Loose, Win;
    public Text Kill, Bullet;

    // Use this for initialization
    void Awake ()
    {
        Help_Script.cnt_Murder = 0;
        Help_Script.CntBullet = 0;
        Help_Script.EndGame = false;
        Help_Script.CntMobs = 10;
        Help_Script.CntHP = 3;
        Win.SetActive(false);
        Loose.SetActive(false);
	    GameObject clone = Instantiate(GG[Help_Script.SelectGG]);
	    clone.transform.position = new Vector3(0f, 0f, 10f);
    }

    void Update()
    {
        if (Help_Script.CntMobs == 0)
        {
            Win.SetActive(true);
            Help_Script.EndGame = true;

            Help_Script.Save_Records();
        }

        if (Help_Script.CntHP == 0)
        {
            Loose.SetActive(true);
            Help_Script.EndGame = true;

            Kill.text = Help_Script.cnt_Murder.ToString();
            Bullet.text = Help_Script.CntBullet.ToString();

            Help_Script.Save_Records();
        }
    }
}
