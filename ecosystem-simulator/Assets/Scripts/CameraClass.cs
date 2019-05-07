using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraClass : MonoBehaviour
{
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void FixedUpdate()
    {
        float f;
        if (Input.GetKey(KeyCode.Q))
            f = 0.2f;
        else if (Input.GetKey(KeyCode.E))
            f = -0.2f;
        else
            f = 0f;
        transform.Translate(Input.GetAxis("Horizontal") / 5f, Input.GetAxis("Vertical") / 5f, f);
    }
}
