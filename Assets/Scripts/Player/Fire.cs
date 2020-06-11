using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public Rigidbody2D Bullet, Silv_Bullet;
    public float Speed;
    public GameObject Bullet_Pos;
    public GameObject Player;
	
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
        pos.z = transform.position.z - Camera.main.transform.position.z;
        pos = Camera.main.ScreenToWorldPoint(pos);

        Quaternion q = Quaternion.FromToRotation(Vector3.up, pos - transform.position);
        Rigidbody2D go = Instantiate(Bullet, transform.position, q) as Rigidbody2D;
        go.GetComponent<Rigidbody2D>().AddForce(go.transform.up * Speed);

        go.gameObject.GetComponent<AudioSource>().Play();
        Help_Script.CntBullet++;
    }
}
