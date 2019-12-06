using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    private int health;

    public GameObject splatCaster;

    private void Start()
    {
        health = 1;
    }

    private void Die()
    {     
        Vector2 curPos = transform.position;

        GameObject splatCast = Instantiate(splatCaster, curPos, Quaternion.identity) as GameObject;
        splatCast.GetComponent<SplatCaster>().CastSplat(curPos);
        Camera.main.GetComponent<RipplePostProcessor>().RippleEffect(transform.position);

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Die();
        //if (collision.gameObject.name == "Player")
        //{
        //    //health--;
        //    Die();
        //}
    }
}
