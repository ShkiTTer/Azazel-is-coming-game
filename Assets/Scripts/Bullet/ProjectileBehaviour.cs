using Assets.Scripts.Character;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public AudioClip shootSound;
    public int collisionsToDestroy = 1;
    private Vector2 veloc;
    private Vector2 position;
    private float inertia;
    private float drag;
    Rigidbody2D rb;

    void Awake()
    {
        AudioSource.PlayClipAtPoint(shootSound, transform.position);
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), GameObject.FindWithTag("Player").GetComponent<Collider2D>());
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        veloc = rb.velocity;
        position = rb.position;
    }

    void OnCollisionEnter2D(Collision2D info)
    {
        collisionsToDestroy--;
        if (collisionsToDestroy > 0 && info.gameObject.tag == "Enemy")
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), info.collider);
            rb.velocity = veloc;
            rb.position = position;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
