using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoDestination : MonoBehaviour
{

    public Vector3 destination;
    public bool arrived = false;
    private Vector3 velocity = Vector3.zero;
    void Start()
    {

    }


    void Update()
    {
        if (Vector3.Distance(transform.position, gameObject.GetComponent<GoDestination>().destination) < 0.1f)
        {
            gameObject.GetComponent<HerbivoreIdle>().state = 0;
            if (Random.Range(0f, 1f) < 0.5f)
            {
                //Wait(Random.Range(3 / timeMultiplier, GameObject.Find("gameManager").GetComponent<Game_Manager>().dayLength / (3 * timeMultiplier)));
                Debug.Log("waited");
                arrived = true;
            }
            else
                arrived = true;

        }
        else
        {
            transform.position = Vector3.SmoothDamp(transform.position, gameObject.GetComponent<GoDestination>().destination, ref velocity, 1f,
                            gameObject.GetComponent<HerbivoreIdle>().speed * 1.5f * gameObject.GetComponent<Game_Manager>().timeMultiplier, Time.deltaTime);
            gameObject.GetComponent<HerbivoreIdle>().state = 1;
        }
    }
}
