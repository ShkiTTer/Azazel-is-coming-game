﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Btn : MonoBehaviour
{
    public enum Action
    {
        Level,
        Arena,
        Records,
        Exit,
        Bonus,
        CloseRecords,
        Restart,
        Menu,
        NextLevel,
        Resume
    }

    public GameObject Rec;
    public Text Txt;

    void Start()
    {
        Help_Script.LoadRecords();
        Time.timeScale = 1f;
    }

    public void Click(int action)
    {
        switch ((Action) action)
        {
            case Action.Level:
                Help_Script.EndGame = false;
                Help_Script.IsPause = false;
                SceneManager.LoadScene(2, LoadSceneMode.Single);
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
                Help_Script.Weapons[1] = true;
                Help_Script.Weapons[0] = false;
                Help_Script.CurrentWeapon = 1;
                Help_Script.NewLevel(true);
                Help_Script.RunLevel();
                Help_Script.SelectGG = 0;
                break;

            case Action.Arena:
                break;

            case Action.Restart:
                Help_Script.EndGame = false;
                Help_Script.IsPause = false;
                Help_Script.RestartLevel();
                break;

            case Action.Menu:
                Help_Script.EndGame = false;
                Help_Script.IsPause = false;
                Help_Script.ResetStats();
                SceneManager.LoadScene(0);
                break;

            case Action.NextLevel:
                Help_Script.EndGame = false;
                Help_Script.IsPause = false;
                Help_Script.NewLevel();
                Help_Script.RunLevel();
                break;

            case Action.Resume:
                Help_Script.EndGame = false;
                Help_Script.IsPause = false;
                Help_Script.IsPause = false;
                Time.timeScale = 1f;
                break;
        }
    }
}