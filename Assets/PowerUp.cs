using UnityEngine;
using System.Collections;
public class PowerUp : MonoBehaviour
{
    GameObject playerOne;
    GameObject playerTwo;
    GameObject p1Gun;
    GameObject p2Gun;
    GameObject p1Child;
    GameObject p2Child;
    void Start()
    {
        playerOne = GameObject.Find ("TankLeft");
        playerTwo = GameObject.Find("TankRight");
        p1Child = playerOne.transform.FindChild("Turret").gameObject;
        p2Child = playerTwo.transform.FindChild("Turret").gameObject;
        p1Gun = p1Child.transform.FindChild("GunBarrel").gameObject;
        p2Gun = p2Child.transform.FindChild("GunBarrel").gameObject;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "P1Bullet")
        {
            playerOne.GetComponent<Movement>().PowerUp();
            p1Gun.GetComponent<Shooting>().StartPowerUp();
            playerTwo.GetComponent<Movement>().ApplyNerf();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if (other.name == "P2Bullet")
        {
            playerTwo.GetComponent<Movement>().PowerUp();
            p2Gun.GetComponent<Shooting>().StartPowerUp();
            playerOne.GetComponent<Movement>().ApplyNerf();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
