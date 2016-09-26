using UnityEngine;
using System.Collections;

public class PowerUpManager : MonoBehaviour
{
    public GameObject canvas;
    public GameObject[] powerUps;

    [Tooltip("Spawns a new power every x seconds")]
    public float spawnTime;
    public GameObject[] spawnPositions;
    float lastSpawn;
    int offset;

	void Start ()
    {
        spawnPositions = GameObject.FindGameObjectsWithTag("PickUpSpawn");
	}
	
	void Update ()
    {
        if (Time.time > lastSpawn + spawnTime)
        {
            Spawn();
        }
	}

    void Spawn()
    {
        lastSpawn = Time.time;
        GameObject clone = Instantiate(powerUps[Random.Range(0, powerUps.Length)], spawnPositions[Random.Range(0,spawnPositions.Length)].transform.position, Quaternion.identity) as GameObject;
        clone.transform.SetParent(canvas.transform);
    }
}
