using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergySystem : MonoBehaviour
{
    [SerializeField]
    private float energy;

    public EnergySystem()
    {
        this.energy = 100f;
    }

    public float getEnergy()
    {
        return this.energy;
    }

    public void setEnergy(float f)
    {
        this.energy = f;
    }
}
