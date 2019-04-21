using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : RandomPosition
{

    private GameObject groundPrefab;
    private GameObject forest;

    private bool day;
    private int dayCounter;
    [SerializeField]
    private int forestToBeGenerated;
    private float timeMultiplier;
    private int seasonLengthInDays;
    private int dayLengthInSeconds;
    private int yearLengthInSeasons;
    private float currentTimeOfDay;
    [SerializeField]
    private Vector3 worldScale;



    public World()
    {
        this.day = false;
        this.dayCounter = 0;
        this.forestToBeGenerated = 1;
        this.timeMultiplier = 1f;
        this.seasonLengthInDays = 4;
        this.dayLengthInSeconds = 30;
        this.yearLengthInSeasons = 3;
        this.currentTimeOfDay = 0f;
        this.worldScale = new Vector3(1, 1, 1);

    }

    void Start()
    {
        forest = new GameObject("ForestGroup");
        groundPrefab = Resources.Load("Ground") as GameObject;
        //plantPrefab = Resources.Load("Bamboo") as GameObject;

        GameObject ground = Instantiate(groundPrefab, Vector3.zero, Quaternion.identity);
        ground.transform.localScale = getWorldScale();


        for (int i = 0; i < forestToBeGenerated; i++)
        {
            GameObject f = new GameObject("Forest " + i);
            f.transform.position = getRandomPosition(getWorldScale() - new Vector3(0.2f, 0.2f, 0.2f));
            //f.transform.SetParent(forest.transform);
            f.AddComponent<Forest>();
        }

    }

    private void Update()
    {
        dayCounter = (int)(currentTimeOfDay / dayLengthInSeconds);
    }


    public GameObject getGroundPrefab()
    {
        return this.groundPrefab;
    }

    public int getForestToBeGenerated()
    {
        return this.forestToBeGenerated;
    }

    public bool getDay()
    {
        return this.day;
    }

    public int getDayCounter()
    {
        return this.dayCounter;
    }

    public int getYearLengthInSeasons()
    {
        return this.yearLengthInSeasons;
    }

    public int getSeasonLengthInDays()
    {
        return this.seasonLengthInDays;
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

    public void setTimeMultiplier(float f)
    {
        this.timeMultiplier = f;
    }

    public void setDay(bool set)
    {
        this.day = set;
    }




}
