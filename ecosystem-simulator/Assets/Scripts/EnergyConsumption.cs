using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyConsumption : EnergySystem
{
    private float energyConsumption;

    public float getEnergyConsumption()
    {
        return this.energyConsumption;
    }

    public void setEnergyConsumption(float f)
    {
        this.energyConsumption = f;
    }

    private void Start()
    {
        //gameObject.AddComponent<EnergySystem>();
    }

    private void Update()
    {
        float energy = this.getEnergy();
        //Debug.Log(energy);
        setEnergy(energy - Time.deltaTime);

    }

}
