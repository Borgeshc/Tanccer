using UnityEngine;
using System.Collections;

public class ResetBall : MonoBehaviour
{
    public GameObject canvas;
    public GameObject ball;
    public Transform ballSpawnpoint;
    public void Scored()
    {
        GameObject clone = Instantiate(ball, ballSpawnpoint.position, ballSpawnpoint.rotation) as GameObject;
        clone.name = "Ball";
        clone.transform.SetParent(canvas.transform);
    }
}

/*
 * 0-1023. 
 * var = (value > 1023/2) ? up : down;
 *
 * if (value > 1023/2)
 * var = up;
 * else 
 * var = down;
 */
