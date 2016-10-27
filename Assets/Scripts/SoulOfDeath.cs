using UnityEngine;
using System.Collections;

public class SoulOfDeath : MonoBehaviour {
    public Vector3 movement = new Vector3(0, 0, 0);
    public float timer = 0;
    public float despawnTime = 4.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Translate(movement * Time.deltaTime);
        timer += Time.deltaTime;
        if (timer >= despawnTime) {
            Destroy(gameObject);
        }
	}
}
