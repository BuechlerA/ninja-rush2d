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

    public Color backgroundTint;
    public float minSizeMod = 0.8f;
    public float maxSizeMod = 1.5f;
}
