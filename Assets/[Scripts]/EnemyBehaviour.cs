/*
 * Full Name: Hardik Dipakbhai Shah
 * Student ID : 101249099
 * Date Modified : October 19,2021
 * File : EnemyController.cs
 * Description : This is the Enemy Controller Script
 * Revision History : v0.1 > Added Comments to know the Code better before start anything & to include a program header
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
    // Update is called once per frame
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

    private void _Move()
    {
        transform.position += new Vector3(horizontalSpeed * direction * Time.deltaTime, 0.0f, 0.0f);
    }

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
}
