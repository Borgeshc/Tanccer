using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public float speed;

	void Update ()
    {
        if (transform.tag == "PlayerOne")
        {
            GameObject clone = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
            clone.name = "p1Bullet";
        }
        else if (transform.tag == "PlayerTwo")
        {
            GameObject clone = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
            clone.name = "p2Bullet";
        }
	}
}
