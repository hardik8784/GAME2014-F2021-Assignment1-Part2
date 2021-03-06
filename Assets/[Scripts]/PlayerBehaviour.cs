/*
 * Full Name: Hardik Dipakbhai Shah
 * Student ID : 101249099
 * Date Modified : October 19,2021
 * File : PlayerController.cs
 * Description : This is the Player Behaviour Script
 * Revision History : v0.1 > Added Comments to know the Code better before start anything & to include a program header
 *                    v0.2 > Added Movement for the player
 *                    v0.3 > Added Bullet for the player
 */


using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    //public BulletManager bulletManager;

    [Header("Boundary Check")]
    public float horizontalBoundary;

    [Header("Player Speed")]
    public float horizontalSpeed;
    public float maxSpeed;
    public float horizontalTValue;

    [Header("Bullet Firing")]
    public float fireDelay;

    [Header("Player Attack")]
    public Transform bulletSpawn;

    // Private variables
    private Rigidbody2D m_rigidBody;
    private Vector3 m_touchesEnded;

    private BulletManager bulletManager;

    // Start is called before the first frame update
    void Start()
    {
        bulletManager = GameObject.FindObjectOfType<BulletManager>();
        m_touchesEnded = new Vector3();
        m_rigidBody = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Update the function every frame
    /// </summary>
    void Update()
    {
        _Move();
        _CheckBounds();
        checkFire();
        
        //_FireBullet();
    }

    //private void _FireBullet()
    //{
    //    // delay bullet firing 
    //    if (Time.frameCount % 60 == 0 && bulletManager.HasBullets())
    //    {
    //        bulletManager.GetBullet(transform.position);
    //    }
    //}
    /// <summary>
    /// Movement for the Player using touch
    /// </summary>
    private void _Move()
    {
        float direction = 0.0f;

        // touch input support
        foreach (var touch in Input.touches)
        {
            var worldTouch = Camera.main.ScreenToWorldPoint(touch.position);

            if (worldTouch.x > transform.position.x)
            {
                // direction is positive
                direction = 1.0f;
            }

            if (worldTouch.x < transform.position.x)
            {
                // direction is negative
                direction = -1.0f;
            }

            m_touchesEnded = worldTouch;

        }

        

        //This is for the Keyboard press 
        if (Input.GetAxis("Horizontal") >= 0.1f)
        {
            // direction is positive
            direction = 1.0f;
        }

        if (Input.GetAxis("Horizontal") <= -0.1f)
        {
            // direction is negative
            direction = -1.0f;
        }

        if (m_touchesEnded.x != 0.0f)
        {
            transform.position = new Vector2(Mathf.Lerp(transform.position.x, m_touchesEnded.x, horizontalTValue), transform.position.y);
        }
        else
        {
            Vector2 newVelocity = m_rigidBody.velocity + new Vector2(direction * horizontalSpeed, 0.0f);
            m_rigidBody.velocity = Vector2.ClampMagnitude(newVelocity, maxSpeed);
            m_rigidBody.velocity *= 0.99f;
        }
    }

    /// <summary>
    /// It will check the bounds for the player so it will not go beyond the screen
    /// </summary>
    private void _CheckBounds()
    {
        // check right bounds
        if (transform.position.x >= horizontalBoundary)
        {
            transform.position = new Vector3(horizontalBoundary, transform.position.y, 0.0f);
        }

        // check left bounds
        if (transform.position.x <= -horizontalBoundary)
        {
            transform.position = new Vector3(-horizontalBoundary, transform.position.y, 0.0f);
        }

    }

    /// <summary>
    /// Whenever player press the space then it will fire up the bullet
    /// </summary>
    private void checkFire()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           // Debug.Log("Key pressed Space");
            bulletManager.GetBullet(bulletSpawn.position, BulletType.PLAYER);
        }
    }

   
}
