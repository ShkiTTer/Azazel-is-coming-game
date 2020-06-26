﻿using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Bonus;
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
        if (info.gameObject.tag == "Projectile")
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), info.collider);
            t = 0.15f;
            mob.CntHp -= (int)(info.gameObject.GetComponent<Projectile>().Damage * Help_Script.DamageMultipliers[Help_Script.CurrentWeapon]);
            mob.ChangeColor(Color.red);
            IsTouch = true;

            if (mob.CntHp <= 0)
            {
                if (Random.Range(0, 1f) < 0.2f)
                {
                    GameObject obj;
                    switch ((BonusType)Random.Range(0, 3))
                    {
                        case BonusType.PlayerSpeed:
                            obj = Instantiate(Resources.Load("speed_up") as GameObject);
                            obj.transform.position = this.gameObject.transform.position;
                            break;
                        case BonusType.Health:
                            obj = Instantiate(Resources.Load("HpBonus") as GameObject);
                            obj.transform.position = this.gameObject.transform.position;
                            break;
                        case BonusType.FiringRate:
                            obj = Instantiate(Resources.Load("firerate_up") as GameObject);
                            obj.transform.position = this.gameObject.transform.position;
                            break;
                    }
                }
            }
        }
    }
}
