using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int destructTime;
	void FixedUpdate ()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = transform.right * speed;
        Destroy(gameObject, destructTime);
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        Vector2 forceVec = gameObject.GetComponent<Rigidbody2D>().velocity * .015f;
        col.gameObject.GetComponent<Rigidbody2D>().AddForce(forceVec);
        Destroy(gameObject);
    }
}
