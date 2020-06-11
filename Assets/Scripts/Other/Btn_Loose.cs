using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Btn_Loose : MonoBehaviour
{
    public void Click(int number)
    {
        if (number == 0)
        {
            gameObject.SetActive(false);
            SceneManager.LoadScene(1);
        }

        if (number == 1)
        {
            SceneManager.LoadScene(0);
        }
    }
}
