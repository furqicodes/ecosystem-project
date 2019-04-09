using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : RandomPosition
{

    private GameObject plants;
    private GameObject groundPrefab;
    private GameObject plantPrefab;

    [SerializeField]
    private bool day;
    private int dayCounter;
    [SerializeField]
    private int plantsToBeGenerated;
    [SerializeField]
    private float timeMultiplier;
    private int seasonLengthInDays;
    private int dayLengthInSeconds;
    private int yearLengthInSeasons;
    [SerializeField]
    private float currentTimeOfDay;
    [SerializeField]
    private Vector3 worldScale;



    public World()
    {
        this.day = false;
        this.dayCounter = 0;
        this.plantsToBeGenerated = 1;
        this.timeMultiplier = 1f;
        this.seasonLengthInDays = 4;
        this.dayLengthInSeconds = 30;
        this.yearLengthInSeasons = 3;
        this.currentTimeOfDay = 0f;
        this.worldScale = new Vector3(1, 1, 1);

    }

    void Start()
    {
        plants = new GameObject("Plants");
        groundPrefab = Resources.Load("Ground") as GameObject;
        plantPrefab = Resources.Load("Bamboo") as GameObject;

        GameObject ground = Instantiate(groundPrefab, Vector3.zero, Quaternion.identity);
        ground.transform.localScale = getWorldScale();

        for (int i = 0; i < plantsToBeGenerated; i++)
        {
            GameObject plant = Instantiate(plantPrefab, getRandomPosition(getWorldScale()), Quaternion.identity);
            plant.transform.SetParent(plants.transform);
        }
    }


    public GameObject getGroundPrefab()
    {
        return this.groundPrefab;
    }

    public GameObject getPlantPrefab()
    {
        return this.plantPrefab;
    }

    public int getPlantsToBeGenerated()
    {
        return this.plantsToBeGenerated;
    }

    public bool getDay()
    {
        return this.day;
    }

    public float getTimeMultiplier()
    {
        return this.timeMultiplier;
    }

    public float getCurrentTimeOfDay()
    {
        return this.currentTimeOfDay;
    }

    public int getDayLengthInSeconds()
    {
        return this.dayLengthInSeconds;
    }

    public Vector3 getWorldScale()
    {
        return this.worldScale;
    }

    public void setCurrentTimeOfDay(float f)
    {
        this.currentTimeOfDay = f;
    }

    public void setGroundPrefab(GameObject obj)
    {
        this.groundPrefab = obj;
    }

    public void setPlantPrefab(GameObject obj)
    {
        this.plantPrefab = obj;
    }

    public void setDay(bool set)
    {
        this.day = set;
    }




}
