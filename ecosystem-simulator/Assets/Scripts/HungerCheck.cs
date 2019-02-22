﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungerCheck : MonoBehaviour
{

    public float starvingPoint;
    [Range(0, 1)]
    public float hungerBar;
    public bool hungry = false;
    public bool dead = false;

    private void Update()
    {
        SetHunger();
        Starve();
        //TurnCorpse();
        if (gameObject.GetComponent<EnergyConsumption>().energy < 1)
        {
            Destroy(gameObject);
        }
    }

    void SetHunger()
    {
        if (hungerBar > 0.75f)
        {
            hungry = true;
        }
        else
        {
            hungry = false;
        }
    }

    void Starve()
    {
        if (hungerBar > starvingPoint)
        {
            //TurnCorpse();
            dead = true;
        }
    }

    //void TurnCorpse()
    //{

    //}
}
