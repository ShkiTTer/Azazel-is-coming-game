using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Bonus
{
    public class PlayerSpeedBonus: Bonus<float>
    {
        public override float BonusValue { get; }
        public override BonusType Type { get; } = BonusType.PlayerSpeed;
    }
}
