using UnityEngine;

public class DayNightCycle : MonoBehaviour
{

    private Light sun;

    private float currentTimeOfDay;
    private float timeMultiplier;
    private float sunInitialIntensity;



    void Start()
    {
        timeMultiplier = GameObject.Find("gameManager").GetComponent<Game_Manager>().timeMultiplier;

        sun = GetComponent<Light>();

        sunInitialIntensity = sun.intensity;
    }

    void Update()
    {
        UpdateSun();

    }

    void UpdateSun()
    {
        currentTimeOfDay = GameObject.Find("gameManager").GetComponent<Game_Manager>().currentTimeOfDay;
        sun.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) - 90, 170, 0);

        float intensityMultiplier = 1;
        if (currentTimeOfDay <= 0.23f || currentTimeOfDay >= 0.75f)
        {
            intensityMultiplier = 0;
        }
        else if (currentTimeOfDay <= 0.25f)
        {
            intensityMultiplier = Mathf.Clamp01((currentTimeOfDay - 0.23f) * (1 / 0.02f));
        }
        else if (currentTimeOfDay >= 0.73f)
        {
            intensityMultiplier = Mathf.Clamp01(1 - ((currentTimeOfDay - 0.73f) * (1 / 0.02f)));
        }

        sun.intensity = sunInitialIntensity * intensityMultiplier;
    }
}
