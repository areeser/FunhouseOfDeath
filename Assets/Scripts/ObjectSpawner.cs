using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour {
    public GameObject obj;
    public Vector3 spawnPoint = new Vector3(0, 0, 0);
    public float timer = 0.0f;
    public float spawnFrequency = 1.0f;


    public float objDespawnTime = 2.0f;
    public Vector2 objMovement = new Vector3(0, 5);
    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnFrequency)
        {
            GameObject o = Instantiate(obj, gameObject.transform.position, new Quaternion()) as GameObject;
            o.transform.parent = gameObject.transform;
            o.GetComponent<ObjectMovement>().movement = objMovement;
            o.GetComponent<ObjectMovement>().despawnTime = objDespawnTime;
            timer = 0.0f;
        }
    }
}
