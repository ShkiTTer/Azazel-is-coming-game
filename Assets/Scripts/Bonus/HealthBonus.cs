using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Bonus
{
    public class HealthBonus: Bonus<Int32>
    {
        public override int BonusValue { get; } = 1;
        public override BonusType Type { get; } = BonusType.Health;
    }
}
