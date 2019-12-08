using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEffect : MonoBehaviour
{
    private SpriteRenderer sprite;
    private GameObject player;

    public float killTime = 0.2f;
    public Color ghostColor;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player");

        sprite.sprite = player.GetComponent<SpriteRenderer>().sprite;
        sprite.color = ghostColor;
    }

    private void Update()
    {
        LeanTween.scale(gameObject, new Vector3(0f, 0f, 0f), 0.5f);
        
        Destroy(gameObject, killTime);
    }
}
