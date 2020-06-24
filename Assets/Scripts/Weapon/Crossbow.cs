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
            shootDelay = 0.8f;
        }

        override protected IEnumerator<WaitForSeconds> FireType(Quaternion q)
        {
            Rigidbody2D projectile = Instantiate(Projectile, Bullet_Pos.position, q) as Rigidbody2D;
            projectile.AddForce(projectile.transform.up * Speed);
            yield return new WaitForSeconds(0f);
            StartCoroutine(ShootDelay());
        }
    }
}