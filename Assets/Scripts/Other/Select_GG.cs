using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Select_GG : MonoBehaviour
{
    public GameObject Story, Sel_GG;
    public GameObject Check;
    public GameObject Txt;
    public float T = 46f;

    void Update()
    {
        T -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) || T <= 0)
        {
            Story.SetActive(false);
            Sel_GG.SetActive(true);
        }
    }

    public void Click(int number)
    {
        Help_Script.SelectGG = number;
        Help_Script.RunLevel();
    }
}