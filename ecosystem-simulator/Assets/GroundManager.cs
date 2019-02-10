using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    [HideInInspector]
    public float worldScale;

    void Start()
    {
        worldScale = GameObject.Find("gameManager").GetComponent<Game_Manager>().worldScale;
        Vector3 scale = new Vector3(worldScale, 1f, worldScale);
        gameObject.transform.localScale = scale;
    }

}
