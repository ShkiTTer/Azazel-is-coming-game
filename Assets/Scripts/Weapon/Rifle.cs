﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Weapon
{
    class Rifle : BaseWeapon
    {
        void Awake()
        {
            Projectile = (Resources.Load("Bullet") as GameObject).GetComponent<Rigidbody2D>();
            Speed = 600;
            shootDelay = 0.6f;
        }

        override protected IEnumerator<WaitForSeconds> FireType(Quaternion q)
        {
            for (int i = 0; i < 3; i++)
            {
                Rigidbody2D projectile = Instantiate(Projectile, Bullet_Pos.position, q) as Rigidbody2D;
                projectile.AddForce(projectile.transform.up * Speed);
                yield return new WaitForSeconds(0.05f);
            }
            StartCoroutine(ShootDelay());
        }
    }
}
