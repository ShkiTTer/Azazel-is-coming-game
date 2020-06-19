﻿using Assets.Scripts.Bullet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Weapon
{
    class Pistol : BaseWeapon
    {
        void Awake()
        {
            Projectile = (Resources.Load("Bullet") as GameObject).GetComponent<Rigidbody2D>();
            Speed = 500;
        }
    }
}