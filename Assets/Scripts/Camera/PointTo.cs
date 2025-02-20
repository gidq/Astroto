using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PointTo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LookAt(new Vector3(-0.3059808f, 0.1846584f, 0.9339577f));
    }

    void LookAt(Vector3 target)
    {
        Vector3 relPos = target - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relPos, transform.up);
        transform.rotation = rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
