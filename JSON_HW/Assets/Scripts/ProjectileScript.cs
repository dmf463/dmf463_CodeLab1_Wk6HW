using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Floor")
        {
            Destroy(this.gameObject);
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
