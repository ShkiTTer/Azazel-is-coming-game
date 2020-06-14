using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public const int MaxHp = 3;

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

            for (int i = 0; i < MaxHp; i++)
            {
                hpObjects.Add(GameObject.Find($"HP_{i + 1}").GetComponent<Image>());
            }
        }

        void Start()
        {
            EnableStayAnimation();
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
    }
}
