using UnityEngine;
using System.Collections;

public class ApplyForce : MonoBehaviour {

    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce((Vector2.right + Vector2.up) * 100, ForceMode2D.Impulse);
        }
    }
}
