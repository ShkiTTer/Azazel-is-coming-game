using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Character
{
    public abstract class Character : MonoBehaviour
    {
        [SerializeField] protected int _cntHp;
        [SerializeField] protected float _speed;

        protected SpriteRenderer renderer;

        public virtual int CntHp
        {
            get => _cntHp;
            set => _cntHp = value;
        }

        public virtual float Speed
        {
            get => _speed;
            protected set => _speed = value;
        }

        protected virtual void Awake()
        {
            renderer = GetComponent<SpriteRenderer>();
        }

        public virtual void ChangeColor(Color color)
        {
            renderer.color = color;
        }
    }
}