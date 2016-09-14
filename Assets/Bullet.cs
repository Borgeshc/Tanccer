using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int destructTime;
	void Update ()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        Destroy(gameObject, destructTime);
	}
}
