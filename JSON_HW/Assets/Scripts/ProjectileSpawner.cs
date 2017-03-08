using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour {

    public float damage;
    public GameObject projectilePrefab;
    public float firingSpeed;
    public GameObject player;
    public float projectilePosTuning;
    private float projectilePosX;
    private float projectilePosY;

    // Use this for initialization
    void Start()
    {

        if (gameObject.name == "Player")
        {
            damage = GameObject.Find("PlayerPowerLevels").GetComponent<PowerLevelScripts>().PlayerPowerLevels[0];
            Debug.Log(gameObject.name + " does " + damage + " damage!");
        }

        if (gameObject.name == "Player2")
        {
            damage = GameObject.Find("PlayerPowerLevels").GetComponent<PowerLevelScripts>().PlayerPowerLevels[1];
            Debug.Log(gameObject.name + " does " + damage + " damage!");
        }

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
        projectile.transform.parent = gameObject.transform;
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
