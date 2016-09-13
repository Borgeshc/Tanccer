using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public float speed;

	void Start ()
    {
	
	}
	

	void Update ()
    {
        if (transform.tag == "PlayerOne")
        {
            Instantiate(bullet, transform.postion, transform.rotation);
        }
        else if (transform.tag == "PlayerTwo")
        {
            Instantiate(bullet, transform.postion, transform.rotation);
        }
	}
}
