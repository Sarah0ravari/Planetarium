using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobeViewControls : MonoBehaviour
{
    public Transform globe;
    const float SPEED = 1080.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float delta = Time.deltaTime;
        bool grabDown = Input.GetButton("Fire2");
        float hAxis, yAxis;
        if (grabDown)
        {
            hAxis = delta * SPEED * Input.GetAxis("Mouse X");
            yAxis = delta * SPEED * Input.GetAxis("Mouse Y");

            transform.RotateAround(globe.position, transform.right, -yAxis);
            transform.RotateAround(globe.position, transform.up, hAxis);
        }
    }
}
