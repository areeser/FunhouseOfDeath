using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour {
    public GameObject obj;
    public Vector3 spawnPoint = new Vector3(0, 0, 0);
    public float timer = 0.0f;
    public float spawnFrequency = 1.0f;
	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnFrequency)
        {
            Instantiate(obj, gameObject.transform.position, new Quaternion());
            timer = 0.0f;
        }
    }
}
