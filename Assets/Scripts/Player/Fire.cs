using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public Rigidbody2D Bullet, Silv_Bullet;
    public float Speed;
    public Transform Bullet_Pos;

    private AudioSource shootSound;

    void Awake()
    {
        shootSound = this.GetComponent<AudioSource>();
    }

	// Update is called once per frame
	void Update ()
    {
        // Стельба при клике ЛКМ
	    if (Input.GetMouseButtonDown(0))
	    {
            if(!Help_Script.EndGame)
	            FireOn();
        }
	}

    //  Сама стельба
    void FireOn()
    {
        Vector3 pos = Input.mousePosition;
        pos.z = Bullet_Pos.position.z - Camera.main.transform.position.z;
        pos = Camera.main.ScreenToWorldPoint(pos);

        Quaternion q = Quaternion.FromToRotation(Vector3.up, pos - Bullet_Pos.position);
        Rigidbody2D bullet = Instantiate(Bullet, Bullet_Pos.position, q) as Rigidbody2D;
        bullet.AddForce(bullet.transform.up * Speed);

        shootSound.Play();
        Help_Script.CntBullet++;
    }
}
