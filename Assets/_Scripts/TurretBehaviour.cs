using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehaviour : MonoBehaviour
{
    private Transform playerTransform;

    public float fireRate = 1f;
    private float nextFire;

    public Bullet bulletPrefab;
    public float bulletSpeed = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.Find("Player").transform;
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (Time.time > nextFire)
        {
            Vector2 shootDirection = (playerTransform.position - transform.position).normalized;
            Bullet bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.BulletCreation(shootDirection, bulletSpeed);
            nextFire = Time.time + fireRate;
        }
    }
}
