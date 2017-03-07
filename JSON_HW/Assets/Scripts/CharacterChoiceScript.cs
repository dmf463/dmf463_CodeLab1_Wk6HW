using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using SimpleJSON;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System;

public class CharacterChoiceScript : MonoBehaviour {


	// Use this for initialization
	void Start () {

        ChooseCharacter("miami", "fl");
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool MyRemoteCertificateValidationCallback(System.Object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
    {
        bool isOk = true;
        // If there are errors in the certificate chain, look at each error to determine the cause.
        if (sslPolicyErrors != SslPolicyErrors.None)
        {
            for (int i = 0; i < chain.ChainStatus.Length; i++)
            {
                if (chain.ChainStatus[i].Status != X509ChainStatusFlags.RevocationStatusUnknown)
                {
                    chain.ChainPolicy.RevocationFlag = X509RevocationFlag.EntireChain;
                    chain.ChainPolicy.RevocationMode = X509RevocationMode.Online;
                    chain.ChainPolicy.UrlRetrievalTimeout = new TimeSpan(0, 1, 0);
                    chain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllFlags;
                    bool chainIsValid = chain.Build((X509Certificate2)certificate);
                    if (!chainIsValid)
                    {
                        isOk = false;
                    }
                }
            }
        }
        return isOk;
    }

    public void ChooseCharacter(string cityName, string stateCode)
    {
        WebClient client = new WebClient();
        ServicePointManager.ServerCertificateValidationCallback = MyRemoteCertificateValidationCallback;
        string content = client.DownloadString("https://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20weather.forecast%20where%20woeid%20in%20(select%20woeid%20from%20geo.places(1)%20where%20text%3D%22" + cityName + "%2C%20" + stateCode + "%22)&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys");
        Debug.Log(content);
        JSONNode place = JSON.Parse(content);
        string temp = place["query"]["results"]["channel"]["item"]["condition"]["temp"];
        print(temp);
        
    }


}
