using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Enemy : MonoBehaviour
{
    public GameObject Bes, Skelet;  // Мобы
    public Transform[] Pos;         // Порталы

    private float T_Spawn = 2f;
    private float T_Pause = 5f;

    private GameObject tmp = null;
    public GameObject Bes_S, Skel_S;

    private int cnt = 0;            // Кол-во заспавленных мобов

	// Use this for initialization
	void Start ()
    {
		//InvokeRepeating("Spawn", 3f, 2f);
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
                    if (cnt < 5)
                        Spawn(Skelet);
                    else if (cnt > 5 && cnt < 11)
                        Spawn(Bes);
                    else if (cnt == 5)
                    {
                        T_Pause = 5f;
                        cnt++;
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

        int n = (int)Random.Range(0f, 3.5f);
        clone.transform.position = Pos[n].position;

        cnt++;
    }
}
