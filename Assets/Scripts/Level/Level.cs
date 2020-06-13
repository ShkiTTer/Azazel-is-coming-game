using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Enemy;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Level
{
    public class Level: BaseLevel
    {
        public override int SceneNumber { get; } = 1;
        public override Dictionary<MobType, double> Mobs { get; }
        
        public Level(int wavesCount, Dictionary<MobType, double> mobsProportion)
        {
            Mobs = mobsProportion;
            GenerateWaves(wavesCount, wavesCount * 12);
        }
    }
}
