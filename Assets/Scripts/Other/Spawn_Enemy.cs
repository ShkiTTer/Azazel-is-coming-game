using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Enemy;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawn_Enemy : MonoBehaviour
{
    public GameObject[] MobPrefabs; // Мобы
    public Transform[] Pos; // Порталы

    private float T_Spawn = 2f;
    private float T_Pause = 5f;

    private int cnt = 0; // Кол-во заспавленных мобов

    private List<MobType> Mobs;
    private int currentWave = 0;
    private Wave wave;
    private System.Random rnd = new System.Random();

    // Use this for initialization
    void Start()
    {
        GetNewWave();
    }

    private void GetNewWave()
    {
        Mobs = new List<MobType>();

        foreach (var mob in Help_Script.CurrentLevel.Waves[currentWave].Mobs)
        {
            Mobs.AddRange(Enumerable.Repeat(mob.Key, mob.Value));
        }
    }

    void Update()
    {
        if (!Help_Script.EndGame)
        {
            T_Pause -= Time.deltaTime;

            if (T_Pause <= 0)
            {
                T_Spawn -= Time.deltaTime;

                if (T_Spawn <= 0)
                {
                    var mob = rnd.Next(Mobs.Count);

                    Spawn(MobPrefabs[(int) Mobs[mob]]);

                    Mobs.RemoveAt(mob);

                    if (Mobs.Count == 0)
                    {
                        currentWave++;
                        GetNewWave();
                        T_Pause = 5f;
                    }

                    T_Spawn = 2f;
                }
            }
        }
    }

    // Спавн мобов
    void Spawn(GameObject ob)
    {
        GameObject clone = Instantiate(ob);

        int n = (int) Random.Range(0f, 3.5f);
        clone.transform.position = Pos[n].position;

        cnt++;
    }
}