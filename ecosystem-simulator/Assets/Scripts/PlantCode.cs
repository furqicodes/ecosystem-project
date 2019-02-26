using UnityEngine;

public class PlantCode : MonoBehaviour
{
    private float timeMultiplier;
    private float dayLength;
    public float t;
    public float energy;

    private bool day;

    private void Start()
    {
        dayLength = GameObject.Find("gameManager").GetComponent<Game_Manager>().dayLength;
        energy = dayLength / 2;
    }

    private void Update()
    {
        timeMultiplier = GameObject.Find("gameManager").GetComponent<Game_Manager>().timeMultiplier;
        day = GameObject.Find("gameManager").GetComponent<Game_Manager>().day;

        transform.localScale = new Vector3(energy / dayLength, 0.3f, energy / dayLength);

        if (energy < dayLength * 1.5f && day)
        {
            energy += Time.deltaTime * timeMultiplier;
        }

        else if (!day)
        {
            energy -= Time.deltaTime * timeMultiplier / 4;
        }


    }

}
