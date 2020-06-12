using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Btn : MonoBehaviour
{
    public enum Action
    {
        Level, Arena, Records, Exit, Bonus, CloseRecords
    }

    public GameObject Rec;
    public Text Txt;

    void Start()
    {
        Help_Script.LoadRecords();
    }

    public void Click(int action)
    {
        switch ((Action) action)
        {
            case Action.Level:
                SceneManager.LoadScene(3);
                break;

            case Action.Exit:
                Application.Quit();
                break;

            case Action.Records:
                Rec.SetActive(true);
                Txt.text = "";

                Txt.text += Help_Script.Records[0].ToString();

                break;

            case Action.CloseRecords:
                Rec.SetActive(false);
                break;

            case Action.Bonus:
                SceneManager.LoadScene(2);
                Help_Script.SelectGG = 0;
                break;

            case Action.Arena:
                break;
        }
    }
}
