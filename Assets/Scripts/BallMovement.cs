using UnityEngine;
using System.Collections;

public class BallMovement : Photon.MonoBehaviour {

    Vector3 position;
    Quaternion rotation;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position = Vector3.Lerp(transform.position, position, 0.1f);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 0.1f);
	}

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if(photonView.isMine)
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
}
