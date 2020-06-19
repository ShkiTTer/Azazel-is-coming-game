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
        if (info.gameObject.tag == "Player")
        {
            Physics2D.IgnoreCollision(this.GetComponent<CircleCollider2D>(), info.collider);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
