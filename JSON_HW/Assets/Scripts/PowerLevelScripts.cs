using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerLevelScripts : MonoBehaviour {

    public List<float> PlayerPowerLevels;

	// Use this for initialization
	void Start () {

        PlayerPowerLevels = new List<float>();
	}
	
	// Update is called once per frame
	void Update () {

        DontDestroyOnLoad(this);
		
	}
}
