using UnityEngine;
using System.Collections;

public class HerbivoreCode : MonoBehaviour
{
    private Renderer render;

    public Vector3 destination;

    public float speed = 1.0f;
    private float waitProbability = 1f;
    private float timer = 0f;

    public bool isWaiting = false;

    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        render = this.GetComponent<Renderer>();
        // pick a random color
        float k = Random.Range(0.20f, 0.40f);
        Color newColor = new Color(k, k, k, 1.0f);
        // apply it on current object's material
        render.material.color = newColor;
    }


    void Update()
    {

        MoveToDestination();

    }


    void Wait(float waitTime)
    {
        isWaiting = true;
        if (timer < waitTime)
        {
            timer += Time.deltaTime * GameObject.Find("gameManager").GetComponent<Game_Manager>().timeMultiplier;
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
                Wait(Random.Range(3f, GameObject.Find("gameManager").GetComponent<Game_Manager>().dayLength / 3));
            else
                SetDestination();

        }
        else if (!isWaiting)
        {
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, 1f, speed * 1.5f, Time.deltaTime);
            transform.LookAt(destination);
        }
    }


    void SetDestination()
    {
        destination = GameObject.Find("gameManager").GetComponent<Game_Manager>().PickPosition(gameObject.transform.localScale.y / 2);
        waitProbability = Random.Range(0f, 1f);
    }


}
