using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Enemy;
using UnityEngine;

public class Wave
{
    public int MobsCount { get; }
    public Dictionary<MobType, int> Mobs { get; } = new Dictionary<MobType, int>();

    public Wave(int mobsCount, Dictionary<MobType, double> percents)
    {
        MobsCount = mobsCount;

        foreach (var percent in percents)
        {
            Mobs.Add(percent.Key, Mathf.RoundToInt(mobsCount * (float)percent.Value));
        }
    }
}
