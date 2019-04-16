using UnityEngine;

public class Panda : LivingBeing
{
    public GameObject target;

    private void Awake()
    {
        gameObject.AddComponent<Movement>();
        gameObject.AddComponent<LivingBeing>();
        gameObject.transform.GetChild(0).gameObject.AddComponent<DetectionSystem>();
        setSpeed(Random.Range(0.75f, 1.25f));
    }

    private void Update()
    {
        target = gameObject.GetComponentInChildren<DetectionSystem>().getNearestObject();
        Movement movement = this.GetComponent<Movement>();
        //Debug.Log(getSpeed());
    }


}
