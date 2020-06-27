using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Enemy;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Level
{
    public abstract class BaseLevel
    {
        public List<Wave> Waves { get; protected set; } = new List<Wave>();
        public abstract int SceneNumber { get; }
        public abstract Dictionary<MobType, double> Mobs { get; }

        public void RunLevel()
        {
            SceneManager.LoadScene(SceneNumber);
        }

        protected void GenerateWaves(int wavesCount, int mobsCount)
        {
            var waveProportion = new List<int>
            {
                Mathf.RoundToInt(wavesCount * 0.2f),
                Mathf.RoundToInt(wavesCount * 0.6f),
            };
            waveProportion.Add(wavesCount - waveProportion.Sum());

            var mobsProportion = new List<int>
            {
                Mathf.RoundToInt(mobsCount * 0.1f),
                Mathf.RoundToInt(mobsCount * 0.6f),
                Mathf.RoundToInt (mobsCount * 0.3f)
            };

            for (int i = 0; i < waveProportion.Count; i++)
            {
                var delta = mobsProportion[i] / waveProportion[i] / 2;

                for (int j = 0; j < waveProportion[i]; j++)
                {
                    Waves.Add(new Wave(delta, Mobs));
                }
            }
        }
    }
}