using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour {

    public GameObject projectilePrefab;
    public float firingSpeed;
    public GameObject player;
    public float projectilePosTuning;
    private float projectilePosX;
    private float projectilePosY;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (this.transform.localScale.x == (-1))
        {
            projectilePosX = (player.transform.position.x) - projectilePosTuning;
        }
        else
        {
            projectilePosX = (player.transform.position.x) + projectilePosTuning;
        }
        projectilePosY = player.transform.position.y;

    }

    public void shootProjectile()
    {
        Vector2 projectilePos = new Vector3(projectilePosX, projectilePosY);
        GameObject projectile = Instantiate(projectilePrefab, projectilePos, Quaternion.identity) as GameObject;
        if (this.transform.localScale.x == (-1))
        {
            projectile.GetComponent<Rigidbody>().velocity = new Vector3(-firingSpeed, 0, 0);
        }
        else
        {
            projectile.GetComponent<Rigidbody>().velocity = new Vector3(firingSpeed, 0, 0);
        }
    }
}
