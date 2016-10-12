using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public float positionValue;
    public float speed;
    float vertical;
    float vertical2;
    //AudioSource source;
    Rigidbody2D rb;
    bool isPlaying;
    RectTransform rt;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rt = GetComponent<RectTransform>();
        //source = GetComponent<AudioSource>();
    }
	void FixedUpdate ()
    {
        if (transform.tag == "PlayerOne")
        {
            positionValue = Mathf.Clamp(positionValue, 40, Screen.height -40);
            rt.position = new Vector3(Screen.width * .1f , positionValue, 0);
            //vertical = Input.GetAxis("Vertical") * speed;
            //vertical *= Time.deltaTime;
            //rb.velocity = new Vector2(0, vertical);
        }
        else if (transform.tag == "PlayerTwo")
        {
            positionValue = Mathf.Clamp(positionValue, 40, Screen.height - 40);
            rt.position = new Vector3(Screen.width - (Screen.width * .1f), positionValue, 0);
            //vertical2 = Input.GetAxis("Vertical2") * speed;
            //vertical2 *= Time.deltaTime;
            //rb.velocity = new Vector2(0, vertical2);
        }

        //if (rb.velocity.y != 0f && !isPlaying)
        //{
        //    isPlaying = true;
        //    source.Play();
        //}
        //else
        //{
        //    isPlaying = false;
        //    source.Stop();
        //}
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
