using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public float shootFreq;

    GameObject canvas;
    float lastShot;
    void Start()
    {
        canvas = GameObject.Find("Canvas"); 
    }
	void Update ()
    {
        if (transform.tag == "PlayerOne")
        {
            if (Input.GetButtonDown("Fire1") && Time.time > lastShot + shootFreq)
            {
                lastShot = Time.time;
                GameObject clone = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
                clone.transform.SetParent(canvas.transform);
            }
        }
        else if (transform.tag == "PlayerTwo" && Time.time > lastShot + shootFreq)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                lastShot = Time.time;
                GameObject clone = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
                clone.transform.SetParent(canvas.transform);
            }
        }
	}
}
