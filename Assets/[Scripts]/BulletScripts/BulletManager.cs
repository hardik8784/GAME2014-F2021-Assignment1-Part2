/*
 * Full Name: Hardik Dipakbhai Shah
 * Student ID : 101249099
 * Date Modified : October 19,2021
 * File : EnemyController.cs
 * Description : This is the BulletManager Script
 * Revision History : v0.1 > Added Comments to know the Code better before start anything & to include a program header
 *                    v0.2 > Added EnemyBulletPool & PlayerBulletPool
 *                    v0.3 > Added Function to getthe bullet and return the bullet
 */



using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[System.Serializable]
public class BulletManager : MonoBehaviour
{
    public Queue<GameObject> enemyBulletPool;
    public Queue<GameObject> playerBulletPool;
    public int enemyBulletNumber;
    public int playerBulletNumber;
    //public GameObject bulletprefab;
    private BulletFactory factory;

    // Start is called before the first frame update
    void Start()
    {
        enemyBulletPool = new Queue<GameObject>();
        playerBulletPool = new Queue<GameObject>();
        factory = GetComponent<BulletFactory>();
    }

    // Update is called once per frame
    void Update()
    {
       // BuildBulletPool();
        //GetBullet();
        //returnBullet();
    }

    /// <summary>
    /// Adding the bullet into the Queue
    /// </summary>
    /// <param name="type"></param>
    private void AddBullet(BulletType type = BulletType.ENEMY)
    {
        //var temp_bullet = Instantiate(bulletprefab);
        //temp_bullet.SetActive(false);
        //temp_bullet.transform.parent = transform;
        var temp_bullet = factory.createBullet();

        switch(type)
        {
            case BulletType.ENEMY:
                enemyBulletPool.Enqueue(temp_bullet);
                enemyBulletNumber++;
                break;
            case BulletType.PLAYER:
                playerBulletPool.Enqueue(temp_bullet);
                playerBulletNumber++;
                break;
        }

       
        
    }

    //private void BuildBulletPool()
    //{
    //   for(int i = 0; i< enemyBulletNumber;i++)
    //    {
    //        AddBullet();
    //    }
    //}

    /// <summary>
    /// Whenever needed, getting the bullet from the Pool.
    /// </summary>
    /// <param name="spawnPosition"></param>
    /// <param name="type"></param>
    /// <returns></returns>
    public GameObject GetBullet(Vector2 spawnPosition, BulletType type = BulletType.ENEMY)
    {
        GameObject temp_bullet = null;
        switch(type)
        {
            case BulletType.ENEMY:
                if (enemyBulletPool.Count < 1)
                {
                    AddBullet();
                    //enemyBulletNumber++;
                }
                temp_bullet = enemyBulletPool.Dequeue();
                temp_bullet.transform.position = spawnPosition;
                temp_bullet.SetActive(true);
                //return temp_bullet;
                break;
            case BulletType.PLAYER:
                //Debug.Log("add");
                if (playerBulletPool.Count < 1)
                {
                    AddBullet(BulletType.PLAYER);
                    //enemyBulletNumber++;
                }
                temp_bullet = playerBulletPool.Dequeue();
                temp_bullet.transform.position = spawnPosition;
                temp_bullet.SetActive(true);
                //return temp_bullet;
                break;
        }
        return temp_bullet;


        //if( enemyBulletPool.Count < 1)
        //{
        //    AddBullet();
        //    //enemyBulletNumber++;
        //}
        //var temp_bullet = enemyBulletPool.Dequeue();
        //temp_bullet.transform.position = spawnPosition;
        //temp_bullet.SetActive(true);
        //return temp_bullet;
    }

    /// <summary>
    /// If the bullet goes off screen, it will be return back to the Queue
    /// </summary>
    /// <param name="returened_bullet"></param>
    /// <param name="type"></param>
    public void returnBullet(GameObject returened_bullet, BulletType type = BulletType.ENEMY)
    {
        returened_bullet.SetActive(false);
        

        switch(type)
        {
            case BulletType.ENEMY:
                enemyBulletPool.Enqueue(returened_bullet);
                break;
            case BulletType.PLAYER:
                playerBulletPool.Enqueue(returened_bullet);
                break;
        }
        
    }

}
