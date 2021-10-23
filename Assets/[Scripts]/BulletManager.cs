using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletManager : MonoBehaviour
{
    public Queue<GameObject> bulletPool;
    public int bulletNumber;
    //public GameObject bulletprefab;
    private BulletFactory factory;

    // Start is called before the first frame update
    void Start()
    {
        bulletPool = new Queue<GameObject>();
        factory = GetComponent<BulletFactory>();
    }

    // Update is called once per frame
    void Update()
    {
        BuildBulletPool();
        //GetBullet();
        //returnBullet();
    }

    private void AddBullet()
    {
        //var temp_bullet = Instantiate(bulletprefab);
        //temp_bullet.SetActive(false);
        //temp_bullet.transform.parent = transform;
        var temp_bullet = factory.createBullet();
        bulletPool.Enqueue(temp_bullet);
    }

    private void BuildBulletPool()
    {
       for(int i = 0; i< bulletNumber;i++)
        {
            AddBullet();
        }
    }

    public GameObject GetBullet(Vector2 position)
    {
        if( bulletPool.Count < 1)
        {
            AddBullet();
            bulletNumber++;
        }
        var temp_bullet = bulletPool.Dequeue();
        temp_bullet.transform.position = position;
        temp_bullet.SetActive(true);
        return temp_bullet;
    }

    public void returnBullet(GameObject returened_bullet)
    {
        returened_bullet.SetActive(false);
        bulletPool.Enqueue(returened_bullet);
    }

}
