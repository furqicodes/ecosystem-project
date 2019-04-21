using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPosition : MonoBehaviour
{
    private Vector3 randomPosition;


    public Vector3 getRandomPosition(Vector3 worldScale)
    {
        this.randomPosition = new Vector3(Random.Range(-5f * worldScale.x, 5f * worldScale.x), 0, Random.Range(-5f * worldScale.z, 5f * worldScale.z));
        return randomPosition;
    }

    public Vector3 readRandomPosition()
    {
        return this.randomPosition;
    }

    public Vector3 getRandomInRadius(float radius)
    {
        return new Vector3(Random.insideUnitSphere.x * radius, 0, Random.insideUnitSphere.z * radius);
    }

}
