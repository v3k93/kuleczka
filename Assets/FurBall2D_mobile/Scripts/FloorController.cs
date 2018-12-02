using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour {

    public float lifeTime = 2;
    private float time = 0;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
		if (time > lifeTime)
        {
            Destroy(this);
        }
	}
}
