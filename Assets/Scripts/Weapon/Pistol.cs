using Assets.Scripts.Bullet;
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
            shootDelay = 0.4f;
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
