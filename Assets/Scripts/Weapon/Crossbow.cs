using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Weapon
{
    class Crossbow : BaseWeapon
    {
        void Awake()
        {
            Projectile = (Resources.Load("Bolt") as GameObject).GetComponent<Rigidbody2D>();
            Speed = 450;
        }
    }
}
