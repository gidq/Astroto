using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    float horizontal;
    float vertical;
    [SerializeField] float rotationSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void rotate()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        Vector3 rotateVector = new Vector3 (vertical, horizontal, 0);
        transform.Rotate(rotateVector * rotationSpeed);

        if (Input.GetKey(KeyCode.R))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rotate();
    }
}
