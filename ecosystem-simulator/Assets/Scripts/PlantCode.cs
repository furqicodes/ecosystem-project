using UnityEngine;

public class PlantCode : MonoBehaviour
{
    private float timeMultiplier;
    private float dayLength;
    public float t;
    private bool day;

    private void Start()
    {
        dayLength = GameObject.Find("gameManager").GetComponent<Game_Manager>().dayLength;
        timeMultiplier = GameObject.Find("gameManager").GetComponent<Game_Manager>().timeMultiplier;
    }

    private void Update()
    {
        //timeOfDay = GameObject.Find("gameManager").GetComponent<Game_Manager>().currentTimeOfDay;
        day = GameObject.Find("gameManager").GetComponent<Game_Manager>().day;

        if (day)
        {
            transform.localScale = new Vector3(Mathf.Lerp(0.5f, 1f, t), 0.3f, Mathf.Lerp(0.5f, 1f, t));
            t += (2 * Time.deltaTime) / dayLength;
        }

    }

}
