using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [Header("Bullet Movement")]
    public float Speed;
    public float bulletBounds;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    private void Move()
    {
        transform.position -= new Vector3(0.0f, Speed, 0.0f);
    }

    private void CheckBounds()
    {
        
    }
}
