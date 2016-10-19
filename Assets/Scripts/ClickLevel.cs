using UnityEngine;
using System.Collections;

public class ClickLevel : MonoBehaviour {

    public string toLevel = ""; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnMouseUpAsButton() {
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().ChangeScene(toLevel);
    }
}
