using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public Camera cam;
    public GameObject ground;

    public float worldScale = 1f;

    void Awake()
    {
        Instantiate(ground, Vector3.zero, Quaternion.identity);
        Instantiate(cam, new Vector3(0, 10, 0), Quaternion.identity);

    }
}
