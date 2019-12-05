using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplatterParticle : MonoBehaviour
{
    public ParticleSystem splatterParticle;
    public GameObject splatPrefab;
    public Transform splatHolder;
    private List<ParticleCollisionEvent> collisionEvents = new List<ParticleCollisionEvent>();

    private void Start()
    {
        splatterParticle = GetComponent<ParticleSystem>();
    }

    private void OnParticleCollision(GameObject other)
    {
        ParticlePhysicsExtensions.GetCollisionEvents(splatterParticle, other, collisionEvents);

        int count = collisionEvents.Count;

        for (int i = 0; i < count; i++)
        {
            GameObject splat = Instantiate(splatPrefab, collisionEvents[i].intersection, Quaternion.identity) as GameObject;
            splat.transform.SetParent(splatHolder, true);
            Splat splatScript = splat.GetComponent<Splat>();
            splatScript.Initialize(splat.SplatLocation.Foreground);
        }
    }
}
