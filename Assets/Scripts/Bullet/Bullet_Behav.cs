using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Behav : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D info)
    {
        Destroy(gameObject);
    }
}
