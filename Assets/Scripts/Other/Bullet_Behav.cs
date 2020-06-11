using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Behav : MonoBehaviour
{  
    // Столкновение пули со всем
    void OnCollisionEnter2D(Collision2D info)
    {
        Destroy(gameObject);
    }
}
