using UnityEngine;

public class PlantCode : MonoBehaviour
{
    private float timeOfDay;
    private float dayLength;
    public float t;
    public bool day = false;

    private void Start()
    {
        dayLength = GameObject.Find("gameManager").GetComponent<Game_Manager>().dayLength;
    }

    private void Update()
    {
        timeOfDay = GameObject.Find("gameManager").GetComponent<Game_Manager>().currentTimeOfDay;
        day = (timeOfDay > 0.25f && timeOfDay < 0.75f) ? true : false;

        if (day)
        {
            transform.localScale = new Vector3(Mathf.Lerp(0.5f, 1f, t), 0.3f, Mathf.Lerp(0.5f, 1f, t));
            t += 2 / (dayLength) * Time.deltaTime;
        }

    }

}
