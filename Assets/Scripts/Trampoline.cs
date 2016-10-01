using UnityEngine;
using System.Collections;

public class Trampoline : MonoBehaviour {
    public float timer = 0.0f;
    public float despawnTime = 2.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer >= despawnTime) {
            Destroy(gameObject);
        }
	}
}
