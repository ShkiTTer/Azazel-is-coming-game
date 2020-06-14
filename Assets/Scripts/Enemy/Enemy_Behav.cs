using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Bullet;
using Assets.Scripts.Character;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Behav : MonoBehaviour
{
    private Mob mob;
    private bool IsTouch = false;   
    private float t;

    void Awake()
    {
        mob = GetComponent<Mob>();
    }

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update ()
	{
        Vector2 vectorToPlayer = mob.Player.position - transform.position;        
        transform.rotation = Quaternion.FromToRotation(Vector2.up, vectorToPlayer);
        transform.position += transform.up * mob.Speed * Time.deltaTime;               

	    if (IsTouch)
	    {
	        t -= Time.deltaTime;

	        if (t <= 0)
	        {
                mob.ChangeColor(Color.white);
	            IsTouch = false;    
	        }
	    }

        
    }

    void OnCollisionEnter2D(Collision2D info)
    {
        if (info.gameObject.tag == "Bullet")
        {
            t = 0.15f;
            mob.CntHp -= info.gameObject.GetComponent<Bullet>().Damage;
            mob.ChangeColor(Color.red);
            IsTouch = true;
        }
    }
}
