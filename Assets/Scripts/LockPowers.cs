﻿using UnityEngine;
using System.Collections;

public class LockPowers : MonoBehaviour {
    public static bool AirBlastUnlocked = false;
    public static bool TrampolineUnlocked = false;
    public static bool BalloonUnlocked = false;
    public bool ab;
    public bool tramp;
    public bool balloon;
    public bool unlockPowers = false; 
	// Use this for initialization
	void Start () {
        //unlockPowers = true;
        if (unlockPowers)
        {
            AirBlastUnlocked = true;
            TrampolineUnlocked = true;
            BalloonUnlocked = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
        ab = AirBlastUnlocked;
        tramp = TrampolineUnlocked;
        balloon = BalloonUnlocked;
	}
}
