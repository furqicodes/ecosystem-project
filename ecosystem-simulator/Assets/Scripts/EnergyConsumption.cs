using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyConsumption : MonoBehaviour
{
    private GameObject gameManager;

    private Vector3 bodySize;

    private float timeMultiplier;
    public float consumptionBase = 1.0f;
    public float energy;
    private float dayLength;
    public float consumptionMultiplier;


    private void Start()
    {
        gameManager = GameObject.Find("gameManager");
        timeMultiplier = gameManager.GetComponent<Game_Manager>().timeMultiplier;
        dayLength = gameManager.GetComponent<Game_Manager>().dayLength;
        bodySize = gameObject.transform.localScale;
        energy = dayLength;
        consumptionMultiplier = consumptionBase;

    }

    private void Update()
    {

        energy -= timeMultiplier * consumptionMultiplier * Time.deltaTime / (gameManager.GetComponent<Game_Manager>().seasonLengthInDays * 4); //4 will be replaced with year length in seasons

        gameObject.transform.localScale = new Vector3(energy / dayLength, energy / dayLength, energy / dayLength);


        //if (gameObject.GetComponent<HungerCheck>().dead)
        //{
        //    Rot();
        //}
        //else
        //{
        //    NormalMode();
        //}


    }


    void NormalMode()
    {
        energy -= timeMultiplier * consumptionMultiplier * Time.deltaTime / (gameManager.GetComponent<Game_Manager>().seasonLengthInDays * 4); //4 will be replaced with year length in seasons
    }

    void Rot()
    {
        energy -= timeMultiplier * consumptionMultiplier * Time.deltaTime / (gameManager.GetComponent<Game_Manager>().seasonLengthInDays * 8); //8 will be replaced with year length in seasons*2
    }
}
