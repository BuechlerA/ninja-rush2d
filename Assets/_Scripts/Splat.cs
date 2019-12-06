using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splat : MonoBehaviour
{
    public enum SplatLocation
    {
        Foreground,
        Background
    }

    public Color Tint;
    public float minSizeMod = 0.8f;
    public float maxSizeMod = 1.5f;

    public Sprite[] sprites;

    private SplatLocation splatLocation;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Initialize(SplatLocation splatLocation)
    {
        this.splatLocation = splatLocation;
        SetSprite();
        SetSize();
        SetRotation();

        SetLocationProperties();
    }

    private void SetSprite()
    {
        int randomIndex = Random.Range(0, sprites.Length);
        spriteRenderer.sprite = sprites[randomIndex];
        spriteRenderer.color = new Color(Random.Range(0.3f, 1f), Random.Range(0.1f, 0.2f), Random.Range(0.1f, 0.3f), 1f);

        float value = Random.Range(0f, 1f);
        if (value > 0.5f)
        {
            spriteRenderer.flipX = true;
        }
        if (value < 0.6f)
        {
            spriteRenderer.flipY = true;
        }
    }

    private void SetSize()
    {
        float sizeMod = Random.Range(minSizeMod, maxSizeMod);
        transform.localScale *= sizeMod;
    }

    private void SetRotation()
    {
        float randomRotation = Random.Range(-360f, 360f);
        transform.rotation = Quaternion.Euler(0f, 0f, randomRotation);
    }

    private void SetLocationProperties()
    {
        switch (splatLocation)
        {
            case SplatLocation.Background:
                //spriteRenderer.color = Tint;
                spriteRenderer.maskInteraction = SpriteMaskInteraction.None;
                spriteRenderer.sortingOrder = -1;
                break;
            case SplatLocation.Foreground:
                spriteRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
                spriteRenderer.sortingOrder = 1;
                break;
            default:
                break;
        }
    }
}
