using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public Camera cam;
    public GameObject ground;

    public float worldScale = 1f;
    public float dayLength;
    [Range(0, 5)]
    public float timeMultiplier = 1f;


    [Range(0, 1)]
    public float currentTimeOfDay = 0;

    void Awake()
    {
        Instantiate(ground, Vector3.zero, Quaternion.identity);
        Instantiate(cam, new Vector3(0, 10, 0), Quaternion.identity);

    }

    private void Update()
    {
        currentTimeOfDay += (Time.deltaTime / dayLength) * timeMultiplier;

        if (currentTimeOfDay >= 1)
            currentTimeOfDay = 0;

    }
}
