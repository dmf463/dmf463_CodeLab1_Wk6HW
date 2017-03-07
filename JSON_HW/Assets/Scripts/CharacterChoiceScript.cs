using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using SimpleJSON;

public class CharacterChoiceScript : MonoBehaviour {


	// Use this for initialization
	void Start () {

        ChooseCharacter(null, null);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChooseCharacter(string cityName, string stateCode)
    {
        WebClient client = new WebClient();
        ServicePointManager.ServerCertificateValidationCallback = MyRemoteCertificateValidationCallback;
        string content = client.DownloadString("https://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20weather.forecast%20where%20woeid%20in%20(select%20woeid%20from%20geo.places(1)%20where%20text%3D%22nome%2C%20ak%22)&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys");
        Debug.Log(content);
    }
}
