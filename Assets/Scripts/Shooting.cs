using UnityEngine;
using System.Collections;

public class Shooting : Photon.MonoBehaviour
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
                GameObject clone = PhotonNetwork.Instantiate(bullet.name, transform.position, transform.rotation, 0);
                clone.GetComponent<PhotonView>().RPC("ChildBullet", PhotonTargets.All);
                clone.name = "P1Bullet";
            }
        }
        else if (transform.tag == "PlayerTwo" && Time.time > lastShot + shootFreq)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                lastShot = Time.time;
                GameObject clone = PhotonNetwork.Instantiate(bullet.name, transform.position, transform.rotation, 0);
                clone.GetComponent<PhotonView>().RPC("ChildBullet", PhotonTargets.All);
                clone.name = "P2Bullet";
            }
        }
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
