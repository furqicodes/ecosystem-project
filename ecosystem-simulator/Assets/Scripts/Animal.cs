using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingBeing : MonoBehaviour
{
    private float speed;

    private void Awake()
    {
        gameObject.AddComponent<EnergyConsumption>();
        EnergyConsumption energyConsumption = this.GetComponent<EnergyConsumption>();




    }


    public void setSpeed(float s)
    {
        this.speed = s;
    }

    public float getSpeed()
    {
        return this.speed;
    }


}
