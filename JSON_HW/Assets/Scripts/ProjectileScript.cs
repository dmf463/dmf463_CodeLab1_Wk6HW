using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour {

    ProjectileSpawner projectileSpawner;

	// Use this for initialization
	void Start () {
		
	}

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Floor")
        {
            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerControlScript>().playerHealth -= transform.parent.GetComponent<ProjectileSpawner>().damage;
            Destroy(gameObject);
            Debug.Log(other.gameObject.name + " has " + other.gameObject.GetComponent<PlayerControlScript>().playerHealth + " health!");
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
