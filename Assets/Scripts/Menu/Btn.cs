using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Btn : MonoBehaviour
{
    public GameObject Rec;
    public Text Txt;

    void Start()
    {
        Help_Script.LoadRecords();
    }

    public void Click(int number)
    {
        switch (number)
        {
            case 0:
                SceneManager.LoadScene(3);
                break;

            case 1:
                Application.Quit();
                break;

            case 2:
                Rec.SetActive(true);
                Txt.text = "";

                Txt.text += Help_Script.Records[0].ToString();

                break;

            case 3:
                Rec.SetActive(false);
                break;

            case 4:
                SceneManager.LoadScene(2);
                Help_Script.SelectGG = 0;
                break;
        }
    }
}
