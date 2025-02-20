using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MakeSphere : MonoBehaviour
{
    public LayerMask mask;
    // Start is called before the first frame update
    void Start()
    {
        GameObject Sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        Sphere.transform.position = new Vector3(-0.3059808f, 0.1846584f, 0.9339577f);
        Sphere.transform.rotation = Quaternion.Euler(new Vector3(0,-90,0));

        Sphere.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        Collider col = Sphere.GetComponent<Collider>();
        col.includeLayers = mask;

        if (Sphere.GetComponent<Renderer>() != null)
        {
            Sphere.GetComponent<Renderer>().material.color = Color.red;
        }

        //GameObject Sphere2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        //Sphere2.transform.position = new Vector3(0.42f, 0.90f, -0.10f);

        //if (Sphere2.GetComponent<Renderer>() != null)
        //{
        //    Sphere2.GetComponent<Renderer>().material.color = Color.blue;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
