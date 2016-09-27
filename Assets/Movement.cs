using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public float speed;
    float vertical;
    float vertical2;
	void Update ()
    {

      //  transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)).y, Camera.main.ViewportToWorldPoint(new Vector3(0f, 100f, 0f)).y));

        if (transform.tag == "PlayerOne")
        {
            vertical = Input.GetAxis("Vertical") * speed;
            vertical *= Time.deltaTime;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, vertical);
        }
        else if (transform.tag == "PlayerTwo")
        {
            vertical2 = Input.GetAxis("Vertical2") * speed;
            vertical2 *= Time.deltaTime;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, vertical2);
        }
	}

    public void PowerUp()
    {
        StartCoroutine(MyPowerUp());
    }

    public void ApplyNerf()
    {
        StartCoroutine(GetNerfed());
    }

    IEnumerator MyPowerUp()
    {
        speed = speed * 3;
        transform.localScale = transform.localScale * 2;
        yield return new WaitForSeconds(5);
        transform.localScale = transform.localScale / 2;
        speed = speed / 3;
    }

    IEnumerator GetNerfed()
    {
        speed = speed / 3;
        transform.localScale = transform.localScale / 2;
        yield return new WaitForSeconds(5);
        speed = speed * 3;
        transform.localScale = transform.localScale * 2;
    }
}
