using UnityEngine;
using System.Collections;

public class HerbivoreCode : MonoBehaviour
{
    private Renderer render;//
    private Rigidbody rb;//
    public Vector3 destination;//

    public float speed = 1.0f;//
    private float waitProbability = 1f;//
    private float timeMultiplier;//
    private float timer = 0f;//
    private float dayLength;//
    //public float energy;

    public bool isWaiting = false;//

    private Vector3 velocity = Vector3.zero;//

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();//
        dayLength = GameObject.Find("gameManager").GetComponent<Game_Manager>().dayLength;//
        //energy = dayLength;
        render = this.GetComponent<Renderer>();//
        // pick a random color
        float k = Random.Range(0.20f, 0.40f);//
        Color newColor = new Color(k, k, k, 1.0f);//
        // apply it on current object's material
        render.material.color = newColor;//
        SetDestination();
    }


    void Update()
    {

        float k = gameObject.GetComponent<EnergyConsumption>().energy / dayLength;//
        rb.mass = Mathf.Pow(k, 2);//
        gameObject.GetComponent<EnergyConsumption>().consumptionMultiplier = 10f;//
        speed = 1 / k;//
        destination.y = k / 2;//
        transform.localScale = new Vector3(k, k, k);//
        timeMultiplier = GameObject.Find("gameManager").GetComponent<Game_Manager>().timeMultiplier;//
        MoveToDestination();

    }


    void Wait(float waitTime)
    {
        isWaiting = true;
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

        }
    }


    void SetDestination()
    {
        destination = GameObject.Find("gameManager").GetComponent<Game_Manager>().PickPosition(transform.localScale.y / 2);
        waitProbability = Random.Range(0f, 1f);
        transform.LookAt(destination);
    }



}
