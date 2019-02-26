using UnityEngine;

public class Game_Manager : MonoBehaviour
{

    [Header("GameObjects")]
    public Camera cam;
    public GameObject ground;
    public GameObject plant;
    public GameObject herbivore;
    private GameObject plants;
    private GameObject animals;
    [Space(10)]

    [Header("World Settings")]
    public float worldScale = 1f;
    public float dayLength;
    public int seasonLengthInDays;
    [Range(0, 5)]
    public float timeMultiplier = 1f;
    public float energyTransferRate;
    [Space(10)]

    [Header("World Status")]
    public bool day = false;
    [Range(0, 1)]
    public float currentTimeOfDay = 0;
    [Range(0, 1)]
    public float currentSeasonStatus = 0;
    [Space(10)]

    [Header("Plant Population Settings")]
    public float populationDensity;
    public float fertilityRate;
    public int seasonNumber = 0;
    public int maxPopulation;
    public int plantCount;
    //[Space(10)]


    void Awake()
    {
        Instantiate(ground, Vector3.zero, Quaternion.identity);
        Instantiate(cam, new Vector3(0, 10, 0), Quaternion.identity);

    }

    private void Start()
    {
        plants = new GameObject("Plants");
        animals = new GameObject("Animals");
        GenerateObject(plant, (int)(populationDensity * maxPopulation), 0.15f);
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GenerateObject(herbivore, 1, 0.5f);
        }


    }


    void Season()
    {
        plantCount = GameObject.FindGameObjectsWithTag("Plant").Length;
        populationDensity = populationDensity * (1 - populationDensity) * fertilityRate;
        int k = (int)(populationDensity * maxPopulation);
        if (plantCount < k)
            GenerateObject(plant, k - plantCount, 0.15f);

        else if (k < plantCount)
            DestroyObject("Plant", plantCount - k);

    }

    public Vector3 PickPosition(float height)
    {
        return new Vector3(Random.Range(-worldScale * 5f + 0.5f, worldScale * 5f - 0.5f), height, Random.Range(-worldScale * 5f + 0.5f, worldScale * 5f - 0.5f)); //-0.5f is for avoiding animals from falling out of world
    }

    void GenerateObject(GameObject obj, int repetation, float height)
    {
        for (int i = 0; i < repetation; i++)
        {
            Instantiate(obj, PickPosition(height), Quaternion.identity);
        }

        foreach (var item in GameObject.FindGameObjectsWithTag("Plant"))
        {
            item.transform.parent = plants.transform;
        }
        foreach (var item in GameObject.FindGameObjectsWithTag("Animal"))
        {
            item.transform.parent = animals.transform;
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
