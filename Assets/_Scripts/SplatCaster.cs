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
        Debug.Log(position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity, layerMask);

        if (hit.collider != null)
        {
            GameObject splat = Instantiate(splatPrefab, position, Quaternion.identity) as GameObject;
            splat.transform.SetParent(splatHolder, true);
            Splat splatScript = splat.GetComponent<Splat>();

            ParticleSystem particle = Instantiate(splatParticles, position, Quaternion.identity);
            particle.Play();

            Debug.Log(hit.transform.tag + hit.transform.name);
            Debug.DrawRay(position, hit.point, Color.red, 5f);

            if (hit.collider.gameObject.tag == "Background")
            {
                
                splatScript.Initialize(Splat.SplatLocation.Background);
            }
            else
            {
                splatScript.Initialize(Splat.SplatLocation.Foreground);
            }
        }
    }
}
