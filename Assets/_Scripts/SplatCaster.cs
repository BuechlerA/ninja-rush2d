using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplatCaster : MonoBehaviour
{
    public ParticleSystem splatParticles;
    public GameObject splatPrefab;
    public Transform splatHolder;

    public LayerMask layerMask;

    private void Start()
    {
        splatHolder = GameObject.Find("SplatHolder").transform;
    }

    public void CastSplat(Vector3 position)
    {
        Ray ray = Camera.main.ScreenPointToRay(transform.position);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity, layerMask);

        if (hit.collider != null)
        {
            GameObject splat = Instantiate(splatPrefab, position, Quaternion.identity) as GameObject;
            splat.transform.SetParent(splatHolder, true);
            Splat splatScript = splat.GetComponent<Splat>();

            ParticleSystem particle = Instantiate(splatParticles, position, Quaternion.identity);
            //particle.Play();

            Debug.DrawRay(position, hit.point, Color.red, 5f);
            Debug.Log(hit.transform.name + " " + hit.transform.tag);

            if (hit.collider.gameObject.tag == "Background")
            {
                splatScript.Initialize(Splat.SplatLocation.Background);
            }
            else
            {
                splatScript.Initialize(Splat.SplatLocation.Foreground);
            }
        }

        Destroy(gameObject, 5f);
    }
}
