using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlScript : MonoBehaviour {

	//Variable for controlling speed
	//it is public, so it can been seen outside
	//of this class, including in the inspector
	public float speed = 1;
    public float jumpSpeed;
    bool isJumping = false;
    ProjectileSpawner projectileSpawner;

	//public keyboard keys for controlling movement
	public KeyCode upKey = KeyCode.W;
	public KeyCode downKey = KeyCode.S;
	public KeyCode leftKey = KeyCode.A;
	public KeyCode rightKey = KeyCode.D;
    public KeyCode shootKey = KeyCode.Space;

	// Use this for initialization
	void Start () {

        projectileSpawner = GetComponent<ProjectileSpawner>();

	}
	
	// Update is called once per frame
	void Update () {
        //Call the move function with a direction and a key
        //Move(Vector3.up, upKey);
        Vector3 jumpVelocity = GetComponent<Rigidbody>().velocity;
        if (Input.GetKeyDown(upKey) && isJumping == false)
        {
            isJumping = true;
            GetComponent<Rigidbody>().velocity = new Vector3(0, jumpSpeed, 0);
        }
        if (Input.GetKeyDown(leftKey))
        {
            transform.localScale = new Vector3 (-1, 1, 1);
        }
        if (Input.GetKeyDown(rightKey))
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (Input.GetKeyDown(shootKey))
        {
            projectileSpawner.shootProjectile();
        }
        Move(Vector3.down, downKey);
		Move(Vector3.left, leftKey);
		Move(Vector3.right, rightKey);
	}

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Floor")
        {
            isJumping = false;
        }
    }

	//function for moving the player
	void Move(Vector3 dir, KeyCode key){
		//if the key passed to this function was pressed
		if(Input.GetKey(key)){
			//than translate the player in the direction passed to this function
			//multiplied by the speed and the deltaTime
			transform.Translate(dir * speed * Time.deltaTime);
		}
	}
}
