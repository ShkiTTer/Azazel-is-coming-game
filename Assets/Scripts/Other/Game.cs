using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public GameObject[] GG; // Персонажи
    public GameObject Loose, Win, Pause;
    public Text Kill, Bullet, CntMurder, CntCoin;

    // Use this for initialization
    void Awake()
    {
        Help_Script.cnt_Murder = 0;
        Help_Script.CntBullet = 0;
        Help_Script.CntMobs = Help_Script.CurrentLevel.Waves.Sum(wave => wave.MobsCount);
        GameObject clone = Instantiate(GG[Help_Script.SelectGG]);
        clone.transform.position = new Vector3(0f, 0f, 10f);
    }

    void Start()
    {
        Win.SetActive(false);
        Loose.SetActive(false);
        Pause.SetActive(false);
    }

    void Update()
    {
        Debug.Log(Help_Script.EndGame);

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
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Help_Script.IsPause = true;
                Time.timeScale = 0f;
            }

            Pause.SetActive(Help_Script.IsPause);

            CntMurder.text = Help_Script.cnt_Murder.ToString();

            if (Help_Script.CntMobs == 0)
            {
                Help_Script.EndGame = true;
            }
        }

        CntCoin.text = Help_Script.Money.ToString();
    }
}