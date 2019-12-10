using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector2 directionVec;
    private float bulletSpeed;

    public void BulletCreation(Vector2 directionVector, float speed)
    {
        directionVec = directionVector;
        bulletSpeed = speed;
    }

    public void CheckTimeToFire()
    {
        transform.Translate(directionVec * Time.deltaTime * bulletSpeed);
    }

    public void Update()
    {
        transform.Translate(directionVec * Time.deltaTime * bulletSpeed);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerBehaviour>().PlayerDie();
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
