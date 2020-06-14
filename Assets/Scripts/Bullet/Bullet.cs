using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Bullet
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private int _damage;
        [SerializeField] private BulletType _bulletType;

        public int Damage
        {
            get => _damage;
            private set => _damage = value;
        }

        public BulletType BulletType => _bulletType;
    }
}
