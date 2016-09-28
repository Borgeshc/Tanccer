using UnityEngine;
using System.Collections;

public class Bullet : Photon.MonoBehaviour
{
    public float speed;
    public int destructTime;

    GameObject canvas;

    Vector3 position;
    Quaternion rotation;

    void Awake()
    {
        canvas = GameObject.Find("Canvas");
    }

    void FixedUpdate ()
    {
        if (photonView.isMine)
        {
            //do nothing
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, position, 0.1f);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 0.1f);
        }

        gameObject.GetComponent<Rigidbody2D>().velocity = transform.right * speed;
        Destroy(gameObject, destructTime);
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        Vector2 forceVec = gameObject.GetComponent<Rigidbody2D>().velocity * .25f;
        col.gameObject.GetComponent<Rigidbody2D>().AddForce(forceVec);
        Destroy(gameObject);
    }

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        }
        else
        {
            position = (Vector3)stream.ReceiveNext();
            rotation = (Quaternion)stream.ReceiveNext();
        }
    }

    [PunRPC]
    void ChildBullet()
    {
        transform.SetParent(canvas.transform);
    }
}
