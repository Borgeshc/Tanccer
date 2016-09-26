using UnityEngine;
using System.Collections;
public class PowerUp : MonoBehaviour
{
    GameObject playerOne;
    GameObject playerTwo;
    GameObject p1Gun;
    GameObject p2Gun;
    void Start()
    {
        playerOne = GameObject.Find ("TankLeft");
        playerTwo = GameObject.Find("TankRight");
        p1Gun = playerOne.transform.FindChild("GunBarrel").gameObject;
        p2Gun = playerTwo.transform.FindChild("GunBarrel").gameObject;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "P1Bullet")
        {
            playerOne.GetComponent<Movement>().PowerUp();
            playerOne.GetComponent<Shooting>().StartPowerUp();
            playerTwo.GetComponent<Movement>().ApplyNerf();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if (other.name == "P2Bullet")
        {
            playerTwo.GetComponent<Movement>().PowerUp();
            playerTwo.GetComponent<Shooting>().StartPowerUp();
            playerOne.GetComponent<Movement>().ApplyNerf();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
