using UnityEngine;
using System.Collections;

public class CascadingPlatform : MonoBehaviour {
    public float decayTime = 5.0f;
    public float timeActive = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        timeActive += Time.deltaTime;
        if (timeActive >= decayTime)
        {
            Destroy(gameObject);
        }
	
	}
}
