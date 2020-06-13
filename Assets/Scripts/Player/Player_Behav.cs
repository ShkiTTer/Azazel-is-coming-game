using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Behav : MonoBehaviour
{
    [Tooltip("Скорость передвижения игрока")]public float Speed_Player;
    [Tooltip("Сердечки")]public GameObject[] HP;
    [Tooltip("Спрайты сердечек")]public Sprite FullHP, LoseHP;

    private Vector3 Move_Player;    // Куда идет игрок
    private Animator Anim;          // Аниматор перса
    private Camera Cam;
    private Ray ray;
    private RaycastHit Hit2D;

    private float t;
    private bool IsTouch = false;

	// Use this for initialization
	void Start ()
	{
	    Cam = Camera.main;
	    Anim = GetComponent<Animator>();
	    Anim.SetBool("Stay", true);
        
	    for (int i = 0; i < Help_Script.CntHP; ++i)
	    {
            HP[i] = GameObject.Find("HP_"+(i+1));
	        HP[i].GetComponent<Image>().sprite = FullHP;
	    }
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (!Help_Script.EndGame)
	    {
	        Cam.transform.position = new Vector3(transform.position.x, transform.position.y, 0f);

	        var mousePosition = Input.mousePosition;
	        mousePosition = Cam.ScreenToWorldPoint(mousePosition); //положение мыши из экранных в мировые координаты

	        var angle = Vector2.Angle(Vector2.up, mousePosition - transform.position);
	            //угол между вектором от объекта к мыше и осью х
	        transform.eulerAngles = new Vector3(0f, 0f, transform.position.x < mousePosition.x ? -angle : angle);
	            //немного магии на последок

	        if (Input.GetKey(KeyCode.A)) // Движение влево
	        {
	            transform.position += Vector3.left * Speed_Player * Time.deltaTime;
	            Anim.SetBool("Stay", false);
	            Anim.SetBool("Run", true);
	        }
	        if (Input.GetKey(KeyCode.D)) // Движение вправо
	        {
	            transform.position += Vector3.right * Speed_Player * Time.deltaTime;
	            Anim.SetBool("Stay", false);
	            Anim.SetBool("Run", true);
	        }
	        if (Input.GetKey(KeyCode.W)) // Движение вверх
	        {
	            transform.position += Vector3.up * Speed_Player * Time.deltaTime;
	            Anim.SetBool("Stay", false);
	            Anim.SetBool("Run", true);
	        }
	        if (Input.GetKey(KeyCode.S)) // Движение вниз
	        {
	            transform.position += Vector3.down * Speed_Player * Time.deltaTime;
	            Anim.SetBool("Stay", false);
	            Anim.SetBool("Run", true);
	        }

	        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W) &&
	            !Input.GetKey(KeyCode.S))
	        {
	            Anim.SetBool("Stay", true);
	            Anim.SetBool("Run", false);
	        }

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
    }

    void OnCollisionEnter2D(Collision2D info)
    {
        if (!Help_Script.EndGame)
        {
            if (info.gameObject.tag == "Enemy")
            {
                t = 0.15f;
                GetComponent<SpriteRenderer>().color = Color.red;
                IsTouch = true;
                Help_Script.CntHP -= 1;
                HP[Help_Script.CntHP].GetComponent<Image>().sprite = LoseHP;
            }
        }
    }
}
