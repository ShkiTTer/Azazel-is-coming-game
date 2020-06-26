using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Bonus;
using UnityEngine;

public abstract class ABonus : MonoBehaviour
{
    public abstract BonusType Type { get; }
    public abstract float BonusValue { get; }

    void OnCollisionEnter2D(Collision2D info)
    {
        if (!Help_Script.EndGame)
        {
            if (info.gameObject.tag == "Player")
            {
                Destroy(gameObject);
            }
        }
    }
}
