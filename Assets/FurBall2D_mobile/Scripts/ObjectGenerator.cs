using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour {


    public GameObject ObjectToSpawn;
    public GameObject player;
    public float xLimit = 5;
    public float yLimit = 5;
    private float lastY = 0;

    public float spawnFrequency = 2;

    private float removeTime;
    private float time;
    private float nextSpawn;
    private List<GameObject> initializedObjectsList = new List<GameObject>();

	// Use this for initialization
	void Start () {
        time = 0;
        removeTime = -6;
        nextSpawn = 1 / spawnFrequency;
	}
	
	// Update is called once per frame
	void Update () {
        float delta = Time.deltaTime;

        time += delta;
        removeTime += delta;

        if (time > nextSpawn)
        {
            time = 0;
            Spawn();

        }

        if (removeTime > nextSpawn)
        {
            removeTime = 0;
            Debug.Log("REM1");
            Remove();
        }
        
	}

    void Spawn()
    {
        Vector3 playerPosition = player.transform.position;
        float yBase = playerPosition.y > lastY ? playerPosition.y : lastY;
        float x = playerPosition.x + Random.Range(xLimit*-1, xLimit);
        float y = yBase + Random.Range(1, yLimit);
        lastY = y;
        Debug.Log("player x " + x);
        Debug.Log("player y " + y);
        initializedObjectsList.Add(Instantiate(ObjectToSpawn, new Vector3(x, y, 0), Quaternion.identity));
        
    }

    void Remove()
    {
        Debug.Log("REM2");
        Destroy(initializedObjectsList[0]);
        initializedObjectsList.RemoveAt(0);
        Debug.Log("REM3");
    }
}
