using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    private Light sun;
    private World w;
    private GameObject sunPrefab;

    private void Awake()
    {
        sunPrefab = Resources.Load("Sun") as GameObject;
        w = GameObject.Find("gameManager").GetComponent<World>();
        sun = Instantiate(sunPrefab, new Vector3(0, 3, 0), Quaternion.identity).GetComponent<Light>();
    }

    private void Update()
    {
        w.setCurrentTimeOfDay(w.getCurrentTimeOfDay() + 1f * Time.deltaTime * w.getTimeMultiplier());
        float k = (w.getCurrentTimeOfDay() % w.getDayLengthInSeconds()) / w.getDayLengthInSeconds();
        sun.transform.localRotation = Quaternion.Euler(((k * 360f) - 90f), 170, 0);

        float intensityMultiplier = 1;
        if (k <= 0.23f || k >= 0.75f)
        {
            intensityMultiplier = 0;
            w.setDay(false);
        }
        else if (k <= 0.25f)
        {
            intensityMultiplier = Mathf.Clamp01((k - 0.23f) * (1 / 0.02f));
            w.setDay(true);
        }
        else if (k >= 0.73f)
        {
            intensityMultiplier = Mathf.Clamp01(1 - ((k - 0.73f) * (1 / 0.02f)));
            w.setDay(true);
        }

        sun.intensity = intensityMultiplier;


    }
}
