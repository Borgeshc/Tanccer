using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public float speed;
    float vertical;
    float vertical2;
	void Update ()
    {
        if (transform.tag == "PlayerOne")
        {
            vertical = Input.GetAxis("Vertical") * speed;
            vertical *= Time.deltaTime;
            transform.Translate(0, vertical, 0);
        }
        else if (transform.tag == "PlayerTwo")
        {
            vertical2 = Input.GetAxis("Vertical2") * speed;
            vertical2 *= Time.deltaTime;
            transform.Translate(0, vertical2, 0);
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
