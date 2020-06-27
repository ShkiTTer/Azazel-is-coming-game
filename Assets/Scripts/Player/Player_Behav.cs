using Assets.Scripts.Bonus;
using Assets.Scripts.Character;
using Assets.Scripts.Weapon;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Player_Behav : MonoBehaviour
{
    private Camera Cam;
    private Player player;

    private float t;
    private bool IsTouch = false;

    void Awake()
    {
        Cam = Camera.main;
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
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
                transform.position += Vector3.left * player.Speed * Time.deltaTime;
                player.EnableRunAnimation();
            }

            if (Input.GetKey(KeyCode.D)) // Движение вправо
            {
                transform.position += Vector3.right * player.Speed * Time.deltaTime;
                player.EnableRunAnimation();
            }

            if (Input.GetKey(KeyCode.W)) // Движение вверх
            {
                transform.position += Vector3.up * player.Speed * Time.deltaTime;
                player.EnableRunAnimation();
            }

            if (Input.GetKey(KeyCode.S)) // Движение вниз
            {
                transform.position += Vector3.down * player.Speed * Time.deltaTime;
                player.EnableRunAnimation();
            }

            if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W) &&
                !Input.GetKey(KeyCode.S))
            {
                player.EnableStayAnimation();
            }

            if (Input.GetKeyUp(KeyCode.Alpha1))
            {
                player.SetWeapon<Pistol>(0);
            }
            else if (Input.GetKeyUp(KeyCode.Alpha2))
            {
                player.SetWeapon<Crossbow>(1);
            }
            else if (Input.GetKeyUp(KeyCode.Alpha3))
            {
                player.SetWeapon<Rifle>(2);
            }

            if (IsTouch)
            {
                t -= Time.deltaTime;

                if (t <= 0)
                {
                    player.ChangeColor(Color.white);
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
                player.CntHp--;
                player.ChangeColor(Color.red);
                IsTouch = true;
            }

            if (info.gameObject.tag == "Bonus")
            {
                ABonus bonus = info.gameObject.GetComponent<ABonus>();
                switch (bonus.Type)
                {
                    case BonusType.Health:
                        player.CntHp++;
                        break;
                    case BonusType.PlayerSpeed:
                        player.Speed += bonus.BonusValue;
                        StartCoroutine(Delay(5, () => { player.Speed -= bonus.BonusValue; return true; }));
                        break;
                    case BonusType.FiringRate:
                        Crossbow.shootDelay -= bonus.BonusValue;
                        Rifle.shootDelay -= bonus.BonusValue;
                        Pistol.shootDelay -= bonus.BonusValue;
                        StartCoroutine(Delay(5, () =>
                        {
                            Crossbow.shootDelay += bonus.BonusValue;
                            Rifle.shootDelay += bonus.BonusValue;
                            Pistol.shootDelay += bonus.BonusValue;
                            return true;
                        }));
                        break;
                }
            }
        }
    }

    private IEnumerator<WaitForSeconds> Delay(int seconds, Func<bool> func)
    {
        yield return new WaitForSeconds(seconds);
        func();
    }
}