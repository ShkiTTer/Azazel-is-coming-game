using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Bonus
{
    public class HealthBonus: ABonus
    {
        [SerializeField]
        private int _bonusValue = 1;
        public override float BonusValue => _bonusValue;
        public override BonusType Type { get; } = BonusType.Health;
    }
}
