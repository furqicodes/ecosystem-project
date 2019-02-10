using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
    void Awake()
    {
        Camera cam = gameObject.GetComponent<Camera>();
        //Fit camera to terrain
        cam.orthographicSize = GameObject.Find("gameManager").GetComponent<Game_Manager>().worldScale * 5f;
        cam.transform.rotation = Quaternion.Euler(90f, 0, 0);

    }

}
