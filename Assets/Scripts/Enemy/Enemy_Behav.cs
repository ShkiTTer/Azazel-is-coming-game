using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Behav : MonoBehaviour
{
    [Tooltip("Скорость перемещения")]public float Speed_Move = 3f;
    [Tooltip("Игрок")]public GameObject Player;
    [Tooltip("Кол-во убийств")]public Text Murder;

    private bool IsTouch = false;   // Касание
    private float t;                // Таймер
    public int Health;              // Кол-во HP

	// Use this for initialization
	void Start () {
		Player = GameObject.FindWithTag("Player");
	    Murder = GameObject.Find("Murder_Cnt").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update ()
	{
        Vector2 vectorToPlayer = Player.transform.position - transform.position;        //Разумеется, player - это переменная с объектом игрока.
        transform.rotation = Quaternion.FromToRotation(Vector2.up, vectorToPlayer);
        transform.position += transform.up * Speed_Move * Time.deltaTime;               //speed - скорость в юнитах/секунду.

	    if (IsTouch)
	    {
	        t -= Time.deltaTime;

	        if (t <= 0)
	        {
                GetComponent<SpriteRenderer>().color = Color.white;
	            IsTouch = false;    
	        }
	    }

        
    }

    void OnCollisionEnter2D(Collision2D info)
    {
        if (info.gameObject.tag == "Bullet")
        {
            t = 0.15f;
            GetComponent<SpriteRenderer>().color = Color.red;
            IsTouch = true;

            Health -= 50;

            if (Health <= 0)
            {
                Help_Script.cnt_Murder += 1;
                Help_Script.CntMobs--;
                Murder.text = Help_Script.cnt_Murder.ToString();
                Destroy(gameObject);
            }
        }
    }
}
