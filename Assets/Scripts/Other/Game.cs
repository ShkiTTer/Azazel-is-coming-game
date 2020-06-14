using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
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
        Help_Script.CntMobs = Help_Script.Levels[Help_Script.CurrentLevelNumber].Waves.Sum(wave => wave.MobsCount);
        Win.SetActive(false);
        Loose.SetActive(false);
	    GameObject clone = Instantiate(GG[Help_Script.SelectGG]);
	    clone.transform.position = new Vector3(0f, 0f, 10f);
    }

    void Update()
    {
        if (Help_Script.EndGame)
        {
            if (Help_Script.CntMobs == 0)
            {
                Win.SetActive(true);

                Help_Script.Save_Records();
            }
            else 
            {
                Loose.SetActive(true);

                Kill.text = Help_Script.cnt_Murder.ToString();
                Bullet.text = Help_Script.CntBullet.ToString();

                Help_Script.Save_Records();
            }
        }
    }
}
