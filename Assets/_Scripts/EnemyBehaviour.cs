using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    private int health;

    private void Start()
    {
        health = 1;
    }

    void Die()
    {
        Camera.main.GetComponent<RipplePostProcessor>().RippleEffect(transform.position);
        GetComponent<SplatCaster>().CastSplat(transform.position);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            //health--;
            Die();
        }
    }
}
