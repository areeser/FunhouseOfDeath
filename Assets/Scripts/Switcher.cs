using UnityEngine;
using System.Collections;

public class Switcher : MonoBehaviour {
    //more customizable script for toggling of an individual object

    public float timeCounter;
    public bool isActive = true;
    public int secondDelay = 3;
	// Use this for initialization
	void Start () {
    
	}
	
	// Update is called once per frame
	void Update () {
        timeCounter = Time.time % (2 * secondDelay);
        if (timeCounter <= secondDelay)
        {
            gameObject.GetComponent<Renderer>().enabled = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
        if (timeCounter > secondDelay)
        {
            gameObject.GetComponent<Renderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            isActive = false;
        }
	
	}
}
