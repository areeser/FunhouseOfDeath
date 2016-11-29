using UnityEngine;
using System.Collections;

public class AnchorScript : MonoBehaviour {
    public GameObject CascadingPlatform;
    public float timeElapsed = 0.0f;
    public float anchorActiveTime = 6.0f;
    public float anchorInactiveTime = 3.0f;
    public float timeUntilNextPlatform = 1.0f;
    public bool anchorActive = true;
    public int numberOfPlatformsToSpawn = 5;
    public int numberOfPlatformsSpawned = 0;
    public bool direction = true;
	// Use this for initialization
	void Start () {


    }
	
	// Update is called once per frame
	void Update () {
        timeElapsed += Time.deltaTime;
        Vector3 positionToSpawn = new Vector3(gameObject.transform.position.x + (10 * gameObject.transform.localScale.x * (1 + numberOfPlatformsSpawned)), gameObject.transform.position.y);
        if (!direction)
        {
            positionToSpawn = new Vector3(gameObject.transform.position.x - (10 * gameObject.transform.localScale.x * (1 + numberOfPlatformsSpawned)), gameObject.transform.position.y);
        }
        if (timeElapsed <= anchorActiveTime)
        {
            gameObject.GetComponent<Renderer>().enabled = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            anchorActive = true;
        }
        if (timeElapsed > anchorActiveTime)
        {
            gameObject.GetComponent<Renderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            anchorActive = false;
        }
        if (timeElapsed >= anchorActiveTime + anchorInactiveTime)
        {
            timeElapsed = 0.0f;
            numberOfPlatformsSpawned = 0;
        }
        if (numberOfPlatformsSpawned < numberOfPlatformsToSpawn && timeElapsed >= timeUntilNextPlatform + timeUntilNextPlatform * numberOfPlatformsSpawned)//timeElapsed % anchorActiveTime > numberOfPlatformsSpawned + 1)
        {
            GameObject o = Instantiate(CascadingPlatform, positionToSpawn, new Quaternion()) as GameObject;
            o.transform.parent = gameObject.transform;
            o.GetComponent<CascadingPlatform>().despawnTime = anchorActiveTime;
            numberOfPlatformsSpawned++;
        }
        
	
	}
}
