using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public Camera cam;
    public GameObject ground;
    public GameObject plant;
    private GameObject plants;

    public float worldScale = 1f;
    public float dayLength;
    public int seasonLengthInDays;
    [Range(0, 5)]
    public float timeMultiplier = 1f;

    public bool day = false;

    [Range(0, 1)]
    public float currentTimeOfDay = 0;
    [Range(0, 1)]
    public float currentSeasonStatus = 0;

    public float populationDensity;
    public float fertilityRate;

    public int seasonNumber = 0;
    public int maxPopulation;
    public int plantCount;

    void Awake()
    {
        Instantiate(ground, Vector3.zero, Quaternion.identity);
        Instantiate(cam, new Vector3(0, 10, 0), Quaternion.identity);

    }

    private void Start()
    {
        plants = new GameObject("Plants");
        GenerateObject(plant, (int)(populationDensity * maxPopulation));
        plantCount = GameObject.FindGameObjectsWithTag("Plant").Length;

    }

    private void Update()
    {
        currentTimeOfDay += (Time.deltaTime / dayLength) * timeMultiplier;
        day = (currentTimeOfDay > 0.25f && currentTimeOfDay < 0.75f) ? true : false;

        if (currentTimeOfDay >= 1)
            currentTimeOfDay = 0;

        currentSeasonStatus += (Time.deltaTime / (dayLength * seasonLengthInDays)) * timeMultiplier;

        if (currentSeasonStatus >= 1)
        {
            currentSeasonStatus = 0;
            seasonNumber++;         //World-like seasons will be added.
            Season();
        }


    }


    void Season()
    {
        plantCount = GameObject.FindGameObjectsWithTag("Plant").Length;
        populationDensity = populationDensity * (1 - populationDensity) * fertilityRate;
        int k = (int)(populationDensity * maxPopulation);
        if (plantCount < k)
            GenerateObject(plant, k - plantCount);

        else if (k < plantCount)
            DestroyObject("Plant", plantCount - k);

    }

    public Vector3 PickPosition()
    {
        return new Vector3(Random.Range(-worldScale * 5f + 0.5f, worldScale * 5f - 0.5f), 0.15f, Random.Range(-worldScale * 5f + 0.5f, worldScale * 5f - 0.5f)); //-0.5f is for avoiding animals from falling out of world
    }

    void GenerateObject(GameObject obj, int repetation)
    {
        for (int i = 0; i < repetation; i++)
        {
            Instantiate(obj, PickPosition(), Quaternion.identity);
        }

        foreach (var item in GameObject.FindGameObjectsWithTag("Plant"))
        {
            item.transform.parent = plants.transform;
        }
    }

    void DestroyObject(string obj, int repetation)
    {
        for (int i = 0; i < repetation; i++)
        {
            Destroy(GameObject.FindGameObjectWithTag(obj));
        }
    }

}
