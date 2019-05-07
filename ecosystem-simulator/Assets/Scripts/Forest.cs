using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forest : MonoBehaviour
{
    private GameObject plantPrefab;
    private BoxCollider coll;
    private GameObject[] bambooList;

    private void Start()
    {
        coll = AddBoxCollider();
        gameObject.AddComponent<RandomPosition>();

        plantPrefab = Resources.Load("Bamboo") as GameObject;
        gameObject.transform.SetParent(GameObject.Find("ForestGroup").transform);

        for (int i = 0; i < Random.Range(5, 15); i++)
        {
            GameObject plant = Instantiate(plantPrefab, new Vector3(Random.Range(this.transform.position.x + 2f, this.transform.position.x - 2f), 0f, Random.Range(this.transform.position.z + 2f, this.transform.position.z - 2f)), Quaternion.Euler(-90, 0, 0));
            plant.transform.SetParent(gameObject.transform);

        }

        //Debug.Log(gameObject.name + " " + gameObject.transform.childCount);
    }

    private void Update()
    {
        if (gameObject.transform.childCount == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Plant"))
        {

        }
    }

    public BoxCollider AddBoxCollider()
    {
        gameObject.AddComponent<BoxCollider>();
        coll = gameObject.GetComponent<BoxCollider>();
        coll.isTrigger = true;
        coll.size = new Vector3(4, 0.5f, 4);
        coll.center = new Vector3(0, 0.25f, 0);
        coll.tag = "Forest";
        return coll;
    }

    public Vector3 getRandomInRadius(float radius)
    {
        return new Vector3(Random.insideUnitSphere.x * radius, 0, Random.insideUnitSphere.z * radius);
    }
}
