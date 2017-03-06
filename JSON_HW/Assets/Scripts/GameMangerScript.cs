using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMangerScript : MonoBehaviour {

    public GameObject player1;
    public GameObject player2;

    public Text player1HealthUI;
    public Text player2HealthUI;

	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {

        player1HealthUI.text = player1.GetComponent<PlayerControlScript>().playerHealth.ToString();
        player2HealthUI.text = player2.GetComponent<PlayerControlScript>().playerHealth.ToString();

    }
}
