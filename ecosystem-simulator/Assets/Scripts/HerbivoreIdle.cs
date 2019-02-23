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


    private float dayLength;
    public bool setDestination = false;

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



    }

    void Update()
    {

        Debug.Log("fucking access");
        rb.mass = Mathf.Pow(size.x, 2);

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

        //if (gameObject.GetComponent<GoDestination>().arrived)
        //{
        //    setDestination = true;
        //}


    }

}
