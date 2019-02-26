using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyTransfer : MonoBehaviour
{
    public bool transferStart = false;
    string gTag;
    float transferRate;


    private void Update()
    {
        transferRate = GameObject.Find("gameManager").GetComponent<Game_Manager>().energyTransferRate;
        gTag = gameObject.tag;
        switch (gTag)
        {
            case "Plant":
                if (transferStart)
                    gameObject.GetComponent<PlantCode>().energy -= transferRate * GameObject.Find("gameManager").GetComponent<Game_Manager>().timeMultiplier * Time.deltaTime;
                break;
            case "Animal":
                if (transferStart && gameObject.GetComponentInChildren<CollisionDetection>().nearestObject)
                {
                    gameObject.GetComponent<EnergyConsumption>().energy += transferRate * transferRate * GameObject.Find("gameManager").GetComponent<Game_Manager>().timeMultiplier * Time.deltaTime / 8;
                }
                else if (!transferStart)
                {

                }
                else
                {
                    gameObject.GetComponent<HungerCheck>().hungerBar = 0f;
                }
                break;
            default:
                break;
        }
    }
}
