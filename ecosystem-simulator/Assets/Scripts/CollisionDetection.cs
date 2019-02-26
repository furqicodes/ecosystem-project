using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public List<GameObject> intersected = new List<GameObject>();
    public GameObject nearestObject;

    private void Update()
    {
        FindNearest();
    }

    void FindNearest()
    {
        float nearestDistance = float.PositiveInfinity;

        foreach (var item in intersected)
        {

            for (int i = 0; i < intersected.Count; i++)
            {
                if (!intersected[i])
                    intersected.Remove(intersected[i]);

                float distance = Vector3.Distance(transform.position, intersected[i].transform.position);
                if (nearestDistance > distance)
                {
                    nearestDistance = distance;
                    nearestObject = intersected[i];
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Plant")
        {
            if (!intersected.Contains(other.gameObject))
            {
                intersected.Add(other.gameObject);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {

    }

    private void OnTriggerExit(Collider other)
    {
        intersected.Remove(other.gameObject);
    }
}
