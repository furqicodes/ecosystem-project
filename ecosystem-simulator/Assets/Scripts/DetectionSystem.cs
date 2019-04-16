using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionSystem : MonoBehaviour
{
    private List<GameObject> intersected = new List<GameObject>();
    private GameObject nearestObject = null;

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

    private void OnTriggerExit(Collider other)
    {
        intersected.Remove(other.gameObject);
    }

    public GameObject getNearestObject()
    {
        return this.nearestObject;
    }

    public int getIntersectedSize()
    {
        return this.intersected.Count;
    }

}
