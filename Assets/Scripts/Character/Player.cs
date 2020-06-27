using System;
using Assets.Scripts.Weapon;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Character
{
    public class Player : Character
    {
        private const string AnimationStay = "Stay";
        private const string AnimationRun = "Run";

        private Animator animator;
        private List<Image> hpObjects = new List<Image>();
        private BaseWeapon Weapon;

        public const int MaxHp = 3;
        public List<RuntimeAnimatorController> Controllers;

        public Sprite FullHP, LoseHP;

        public override int CntHp
        {
            get => _cntHp;
            set
            {
                if (value <= MaxHp)
                {
                    _cntHp = value;

                    for (int i = 0; i < value; i++)
                    {
                        hpObjects[i].sprite = FullHP;
                    }

                    for (int i = value; i < MaxHp; i++)
                    {
                        hpObjects[i].sprite = LoseHP;
                    }
                }

                if (value == 0)
                {
                    Help_Script.EndGame = true;
                }
            }
        }

        protected override void Awake()
        {
            base.Awake();
            animator = GetComponent<Animator>();
            Weapon = gameObject.AddComponent(typeof(Pistol)) as Pistol;
            Weapon.Bullet_Pos = GetComponentsInChildren<Transform>()[1];

            for (int i = 0; i < MaxHp; i++)
            {
                hpObjects.Add(GameObject.Find($"HP_{i + 1}").GetComponent<Image>());
            }

            if (Help_Script.CurrentLevel == Help_Script.BonusLevel)
            {
                SetWeapon<Crossbow>(1);
            }
        }

        void Start()
        {
            CntHp = Help_Script.CntHP;
            EnableStayAnimation();
        }

        void Update()
        {
            if (Help_Script.EndGame)
            {
                Help_Script.CntHP = CntHp;
            }
        }

        public void EnableStayAnimation()
        {
            animator.SetBool(AnimationStay, true);
            animator.SetBool(AnimationRun, false);
        }

        public void EnableRunAnimation()
        {
            animator.SetBool(AnimationStay, false);
            animator.SetBool(AnimationRun, true);
        }

        public void SetWeapon<T>(int weaponNum) where T : BaseWeapon
        {
            if (Help_Script.Weapons[weaponNum])
            {
                Help_Script.CurrentWeapon = weaponNum;
                animator.runtimeAnimatorController = Controllers[weaponNum];
                Destroy(Weapon);
                Weapon = gameObject.AddComponent(typeof(T)) as T;
                Weapon.Bullet_Pos = gameObject.GetComponentInChildren<Transform>();
            }
        }
    }
}