/*
 * Full Name: Hardik Dipakbhai Shah
 * Student ID : 101249099
 * Date Modified : October 19,2021
 * File : EnemyController.cs
 * Description : This is the Enemy Behaviour Script
 * Revision History : v0.1 > Added Comments to know the Code better before start anything & to include a program header
 *                    v0.2 > Added movement for the enemy
 *                    v0.3 > Added Firing capabilities for the enemy
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float horizontalSpeed;
    public float horizontalBoundary;
    public float direction;

    [Header("Bullets")]
    public Transform bulletSpawn;
    //public GameObject bulletprefab;
    public int frameDelay;

    private BulletManager bulletManager;


    void Start()
    {
        bulletManager = GameObject.FindObjectOfType<BulletManager>();   
    }
    
    /// <summary>
    /// It will call this every frame
    /// </summary>
    void Update()
    {
        _Move();
        _CheckBounds();
    }

    private void FixedUpdate()
    {
        if(Time.frameCount % frameDelay == 0 )
        {
            bulletManager.GetBullet(bulletSpawn.position);
            //var temp_bullet = Instantiate(bulletprefab);
            //temp_bullet.transform.position = bulletSpawn.position;
        }
    }

    /// <summary>
    /// The movement of the enemy
    /// </summary>
    private void _Move()
    {
        transform.position += new Vector3(horizontalSpeed * direction * Time.deltaTime, 0.0f, 0.0f);
    }

    /// <summary>
    /// It will check the bounds for the enemy
    /// </summary>
    private void _CheckBounds()
    {
        // check right boundary
        if (transform.position.x >= horizontalBoundary)
        {
            direction = -1.0f;
        }

        // check left boundary
        if (transform.position.x <= -horizontalBoundary)
        {
            direction = 1.0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PlayerBullet")
        {
            Debug.Log("Score");

            //Lives = Lives - 1;
            //Debug.Log("Lives: " + Lives);
            //SceneManager.LoadScene("GameOverScreen");
        }
    }
}
