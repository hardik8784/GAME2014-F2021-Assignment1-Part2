using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using TMPro;
//using System;

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
    public int Lives = 3;
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

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        CheckBounds();
    }

    private void Move()
    {
        transform.position += bulletVelocity;
    }

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
            Lives--;
            Debug.Log("Lives: " + Lives);
        }
    }
    
}
