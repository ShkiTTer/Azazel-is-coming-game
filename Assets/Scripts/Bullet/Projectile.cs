using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Bullet
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private int _damage;
        [SerializeField] private ProjectileType _projectileType;

        public int Damage
        {
            get => _damage;
            private set => _damage = value;
        }

        public ProjectileType ProjectileType => _projectileType;
    }
}
