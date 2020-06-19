using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Weapon
{
    abstract class BaseWeapon : MonoBehaviour
    {
        public Rigidbody2D Projectile;
        public Transform Bullet_Pos;
        public float Speed;
        public bool canShoot = true;
        public float shootDelay = 1f;

        abstract protected IEnumerator<WaitForSeconds> FireType(Quaternion q);

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!Help_Script.EndGame)
                    Fire();
            }
        }

        void Fire()
        {
            Vector3 pos = Input.mousePosition;
            pos.z = Bullet_Pos.position.z - Camera.main.transform.position.z;
            pos = Camera.main.ScreenToWorldPoint(pos);

            Quaternion q = Quaternion.FromToRotation(Vector3.up, pos - Bullet_Pos.position);
            if (canShoot)
            {
                canShoot = false;
                StartCoroutine(FireType(q));
            }

            Help_Script.CntBullet++;
        }

        protected IEnumerator<WaitForSeconds> ShootDelay()
        {
            yield return new WaitForSeconds(shootDelay);
            canShoot = true;
        }
    }
}
