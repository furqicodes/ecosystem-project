using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerbivoreIdle : MonoBehaviour
{
    private Vector3 size;

    public int state;
    /* States:
     * 0: Idle
     * 1: Moving
     * 2: !!! Running !!! //will be added soon    
     */

    private Renderer render;
    private Rigidbody rb;

    public float speed = 1.0f;
    //private float timeMultiplier;
    private float dayLength;


    private void Start()
    {
        //Color Setup
        render = this.GetComponent<Renderer>();
        float k = Random.Range(0.20f, 0.40f);
        Color newColor = new Color(k, k, k, 1.0f);
        render.material.color = newColor;

        //Mass Setup
        rb = this.GetComponent<Rigidbody>();

        size = gameObject.transform.localScale;

        dayLength = GameObject.Find("gameManager").GetComponent<Game_Manager>().dayLength;

        SetDestination();

    }

    void Update()
    {
        rb.mass = Mathf.Pow(size.x, 2);

        transform.localScale = Fun(this.GetComponent<EnergyConsumption>().energy / dayLength);

        //timeMultiplier = GameObject.Find("gameManager").GetComponent<Game_Manager>().timeMultiplier;

        speed = size.x;

        switch (state)
        {
            case 0:
                gameObject.GetComponent<EnergyConsumption>().consumptionMultiplier = 0.5f;
                break;
            case 1:
                gameObject.GetComponent<EnergyConsumption>().consumptionMultiplier = 1f;
                break;
            case 2:
                gameObject.GetComponent<EnergyConsumption>().consumptionMultiplier = 2f;
                break;
        }

        if (gameObject.GetComponent<GoDestination>().arrived)
        {
            SetDestination();
        }


    }

    Vector3 Fun(float k)
    {
        return new Vector3(k, k, k);
    }

    void SetDestination()
    {
        gameObject.GetComponent<GoDestination>().destination = GameObject.Find("gameManager").GetComponent<Game_Manager>().PickPosition(transform.localScale.y / 2);
        transform.LookAt(gameObject.GetComponent<GoDestination>().destination);
    }
}
