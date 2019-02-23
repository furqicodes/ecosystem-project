using UnityEngine;
using System.Collections;

public class HerbivoreCode : MonoBehaviour
{

    public Vector3 destination;//

    public float speed = 1.0f;//
    private float waitProbability = 1f;//
    private float timeMultiplier;//
    private float timer = 0f;//
    private float dayLength;//

    public bool isWaiting = false;//

    private Vector3 velocity = Vector3.zero;//

    void Start()
    {

        dayLength = GameObject.Find("gameManager").GetComponent<Game_Manager>().dayLength;

        SetDestination();
    }


    void Update()
    {

        destination.y = transform.localScale.y / 2;
        speed = 1 / transform.localScale.x;
        timeMultiplier = GameObject.Find("gameManager").GetComponent<Game_Manager>().timeMultiplier;//
        if (!gameObject.GetComponent<HungerCheck>().dead)
        {
            MoveToDestination();
        }



    }


    void Wait(float waitTime)
    {
        isWaiting = true;
        gameObject.GetComponent<HerbivoreIdle>().state = 0;
        if (timer < waitTime)
        {
            timer += Time.deltaTime * timeMultiplier;
            isWaiting = true;
        }
        else
        {
            timer = 0f;
            isWaiting = false;
            SetDestination();
        }
    }

    void MoveToDestination()
    {
        if (Vector3.Distance(transform.position, destination) < 0.1f)
        {
            if (waitProbability < 0.5f)
                Wait(Random.Range(3 / timeMultiplier, GameObject.Find("gameManager").GetComponent<Game_Manager>().dayLength / (3 * timeMultiplier)));
            else
                SetDestination();

        }
        else
        {
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, 1f, speed * 1.5f * timeMultiplier, Time.deltaTime);
            gameObject.GetComponent<HerbivoreIdle>().state = 1;
        }
    }


    void SetDestination()
    {
        destination = GameObject.Find("gameManager").GetComponent<Game_Manager>().PickPosition(transform.localScale.y / 2);
        waitProbability = Random.Range(0f, 1f);
        transform.LookAt(destination);
    }



}
