using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour {


    public GameObject ObjectToSpawn;
    public GameObject player;
    public float xLimit = 5;
    public float yLimit = 5;

    public float spawnFrequency = 2;

    private float time;
    private float nextSpawn;

	// Use this for initialization
	void Start () {
        time = 0;
        nextSpawn = 1 / spawnFrequency;
	}
	
	// Update is called once per frame
	void Update () {
        float delta = Time.deltaTime;

        time += delta;

        if (time > nextSpawn)
        {
            time = 0;
            Spawn();

        }
	}

    void Spawn()
    {
        Vector3 playerPosition = player.transform.position;
        float x = playerPosition.x + Random.Range(xLimit*-1, xLimit);
        float y = playerPosition.y + yLimit;
        Debug.Log("player x " + x);
        Debug.Log("player y " + y);
        Instantiate(ObjectToSpawn, new Vector3(x, y, 0), Quaternion.identity);





    }
}
