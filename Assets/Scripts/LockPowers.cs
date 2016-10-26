using UnityEngine;
using System.Collections;

public class LockPowers : MonoBehaviour {
    public static bool AirBlastUnlocked = false;
    public static bool TrampolineUnlocked = false;
    public static bool BalloonUnlocked = false;
    private bool unlockPowers = false; 
	// Use this for initialization
	void Start () {
       // unlockPowers = true;
        if (unlockPowers)
        {
            AirBlastUnlocked = true;
            TrampolineUnlocked = true;
            BalloonUnlocked = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
