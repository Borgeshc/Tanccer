using UnityEngine;
using System.Collections;

public class NetworkPlayer : Photon.MonoBehaviour
{
    GameObject canvas;
    Vector3 position;
    Quaternion rotation;

    void Awake()
    {
        canvas = GameObject.Find("Canvas");
    }

    void Start()
    {
        if (photonView.isMine)
        {
            GetComponent<Movement>().enabled = true;
        }
    }

    void FixedUpdate()
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
    public void ChildPlayer()
    {
        transform.SetParent(canvas.transform);
    }
}
