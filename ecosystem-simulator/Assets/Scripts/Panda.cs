using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panda : LivingBeing
{
    public GameObject target;
    private GameObject wander;
    private GameObject[] array;
    public GameObject komun;

    public bool entered = false;

    private void Awake()
    {
        gameObject.AddComponent<Movement>();
        gameObject.AddComponent<LivingBeing>();
        setSpeed(Random.Range(0.75f, 1.25f));
    }

    private void Update()
    {
        Movement movement = this.GetComponent<Movement>();
        array = GameObject.FindGameObjectsWithTag("Forest");
        if (!target)
        {
            FindNearest();
        }
        else
        {
            if (!entered)
            {
                movement.Move(target, getSpeed(), 1);
            }
            else
            {
                if (!wander)
                {
                    wander = new GameObject();
                }
                wander.transform.position = komun.GetComponent<Forest>().getRandomInRadius(3);
                Debug.DrawLine(wander.transform.position, new Vector3(wander.transform.position.x, wander.transform.position.y + 2f, wander.transform.position.z));
                movement.Move(wander, getSpeed(), 1);
                StartCoroutine("Wander");
            }



        }



    }

    IEnumerator Wander()
    {
        yield return new WaitForSeconds(5);
    }


    void FindNearest()
    {
        float nearestDistance = float.PositiveInfinity;

        foreach (var item in array)
        {

            for (int i = 0; i < array.Length; i++)
            {
                float distance = Vector3.Distance(transform.position, array[i].transform.position);
                if (nearestDistance > distance)
                {
                    nearestDistance = distance;
                    target = array[i];
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Forest")
        {
            komun = other.gameObject;
            entered = true;
        }
    }


}
