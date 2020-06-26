using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Bonus
{
    public class FiringRateBonus: ABonus
    {
        [SerializeField]
        private float _bonusValue;

        public override float BonusValue => _bonusValue;
        public override BonusType Type { get; } = BonusType.FiringRate;
    }
}
