using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static string scene = "LevelSelect";
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void ChangeScene(string newScene) {
        scene = newScene;
        SceneManager.LoadScene(scene);
    }

    public void Death() {
        if (scene == "AirBlast") {
            LockPowers.AirBlastUnlocked = false;
        }
        else if (scene == "Balloon")
        {
            LockPowers.BalloonUnlocked = false;
        }
        else if (scene == "Trampoline")
        {
            LockPowers.TrampolineUnlocked = false;
        }
        SceneManager.LoadScene("GameOver");
    }
}
