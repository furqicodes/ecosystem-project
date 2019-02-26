using UnityEngine;

public class ExistenceCheck : MonoBehaviour
{
    private string gTag;

    void Update()
    {
        gTag = gameObject.tag;
        switch (gTag)
        {
            case "Plant":
                if (gameObject.GetComponent<PlantCode>().energy < 1)
                {
                    Destroy(gameObject);
                }
                break;
            case "Animal":
                if (gameObject.GetComponent<EnergyConsumption>().energy < 10)
                {
                    Destroy(gameObject);
                }
                break;
            default:
                break;
        }
    }
}
