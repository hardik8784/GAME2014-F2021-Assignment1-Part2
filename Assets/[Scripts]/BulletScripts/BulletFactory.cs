/*
 * Full Name: Hardik Dipakbhai Shah
 * Student ID : 101249099
 * Date Modified : October 19,2021
 * File : EnemyController.cs
 * Description : This is the Bullet Factory Script
 * Revision History : v0.1 > Added Comments to know the Code better before start anything & to include a program header
 *                    v0.2 > Create bullet with factory
 */



using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class BulletFactory : MonoBehaviour
{
    [Header("Bullet Types")]
    public GameObject Enemybullet;
    public GameObject PlayerBullet;

    /// <summary>
    /// Create the bullet using the factory
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public GameObject createBullet(BulletType type = BulletType.ENEMY)
    {
        GameObject temp_bullet = null;
        switch(type)
        {
            case BulletType.ENEMY:
                temp_bullet = Instantiate(Enemybullet);
                break;
            case BulletType.PLAYER:
                temp_bullet = Instantiate(PlayerBullet);
                break;
        }
        temp_bullet.transform.parent = transform;
        temp_bullet.SetActive(false);
        return temp_bullet;
    }
}
