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

    void Update()
    {
        if (transform.tag == "PlayerOne" && Time.time > lastShot + shootFreq)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                lastShot = Time.time;
                GameObject clone = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
                clone.name = "P1Bullet";
                clone.transform.SetParent(canvas.transform);
            }
        }
        else if (transform.tag == "PlayerTwo" && Time.time > lastShot + shootFreq)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                lastShot = Time.time;
                GameObject clone = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
                clone.name = "P2Bullet";
                clone.transform.SetParent(canvas.transform);
            }
        }
    }
    public void Shoot ()
    {
        //if (transform.tag == "PlayerOne")
        //{
        //if (Time.time > lastShot + shootFreq)
        //{
                lastShot = Time.time;
                GameObject clone = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
                clone.name = "P1Bullet";
                clone.transform.SetParent(canvas.transform);
            //}
        ////}
        //else if (transform.tag == "PlayerTwo" && Time.time > lastShot + shootFreq)
        //{
        //    if (Input.GetButtonDown("Fire2"))
        //    {
        //        lastShot = Time.time;
        //        GameObject clone = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
        //        clone.name = "P2Bullet";
        //        clone.transform.SetParent(canvas.transform);
        //    }
        //}
	}

    public void StartPowerUp()
    {
        StartCoroutine(PowerOverWhelming());
    }

    IEnumerator PowerOverWhelming()
    {
        shootFreq = shootFreq / 2;
        yield return new WaitForSeconds(5);
        shootFreq = shootFreq * 2;
    }
}
