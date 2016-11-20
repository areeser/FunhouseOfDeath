using UnityEngine;
using System.Collections;

public class Switcher : MonoBehaviour {
    //more customizable script for toggling of an individual object

    public float timeCounter;
    public bool isActive = true;
    public bool firstRun = true;
    public float initialDelay = 0.0f;
    public float activeTime = 3.0f;
    public float inactiveTime = 3.0f;
	// Use this for initialization
	void Start () {
    
	}
	
	// Update is called once per frame
	void Update () {
        timeCounter += Time.deltaTime;
        if (firstRun)
        {
            if (timeCounter <= initialDelay)
            {
                gameObject.GetComponent<Renderer>().enabled = false;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
            else
            {
                timeCounter = 0.0f;
                firstRun = false;
            }
        }
        else
        {
            if (timeCounter <= activeTime)
            {
                gameObject.GetComponent<Renderer>().enabled = true;
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
            }
            else
            {
                gameObject.GetComponent<Renderer>().enabled = false;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                if (timeCounter >= activeTime + inactiveTime)
                {
                    timeCounter = 0;
                }
            }
        }
	}
}
