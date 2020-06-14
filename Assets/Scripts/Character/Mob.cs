﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Character
{
    public class Mob: Character
    {
        public Transform Player;

        public override int CntHp
        {
            get => _cntHp;
            set
            {
                _cntHp = value;

                if (value <= 0)
                {
                    Help_Script.cnt_Murder += 1;
                    Help_Script.CntMobs--;
                    Destroy(gameObject);
                }
            }
        }

        protected override void Awake()
        {
            base.Awake();
            Player = GameObject.FindWithTag("Player").transform;
        }
    }
}
