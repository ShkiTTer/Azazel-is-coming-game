using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public AudioClip shootSound;

    void Awake()
    {
        AudioSource.PlayClipAtPoint(shootSound, transform.position);
    }

    void OnCollisionEnter2D(Collision2D info)
    {
        Destroy(gameObject);
    }
}
