/*
 * Full Name: Hardik Dipakbhai Shah
 * Student ID : 101249099
 * Date Modified : October 19,2021
 * File : EnemyController.cs
 * Description : This is the Bullet Behaviour Script
 * Revision History : v0.1 > Added Comments to know the Code better before start anything & to include a program header
 *                    v0.2 > Added Bullet movement
 *                    v0.3 > Added the function for the BulletManager
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BulletBehaviour : MonoBehaviour
{
    public BulletType type;

    [Header("Bullet Movement")]
    [Range(0.0f,0.5f)]
    public float speed;
    public Bounds bulletBounds;
    public BulletDirection direction;

    private BulletManager bulletManager;
    private Vector3 bulletVelocity;

    //[SerializeField]
    //private TextMeshPro LivesText;
    //private TextMeshPro ScoreText;

    public int Score = 0;
    public int Lives = 1;
    // Start is called before the first frame update
    void Start()
    {
        //LivesText.text = "Lives : 3";
        //ScoreText.text = "Score : 0";

        bulletManager = GameObject.FindObjectOfType<BulletManager>();

        switch(direction)
        {
            case BulletDirection.UP:
                bulletVelocity = new Vector3(0.0f, speed,0.0f);
                break;
            case BulletDirection.DOWN:
                bulletVelocity = new Vector3(0.0f, -speed,0.0f);
                break;
        }
    }

   /// <summary>
   /// Update calls once per frame
   /// </summary>
    void FixedUpdate()
    {
        Move();
        CheckBounds();
    }

    /// <summary>
    /// Movement for the bullet using the velocity
    /// </summary>
    private void Move()
    {
        transform.position += bulletVelocity;
    }

    /// <summary>
    /// using the max and min value checking the bounds for the bullet
    /// </summary>
    private void CheckBounds()
    {
       

        //Check bottom
        if (transform.position.y < bulletBounds.max)
        {
            bulletManager.returnBullet(this.gameObject, type);
            //Destroy(this.gameObject);
        }

        //Check Top
        if (transform.position.y > bulletBounds.min)
        {
            bulletManager.returnBullet(this.gameObject, type);
            //Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Lives = Lives - 1;
            Debug.Log("Lives: " + Lives);
            SceneManager.LoadScene("GameOverScreen");
        }
    }
    
}
