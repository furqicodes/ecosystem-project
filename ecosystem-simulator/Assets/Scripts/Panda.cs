using UnityEngine;

public class Panda : LivingBeing
{
    public GameObject target;

    private void Awake()
    {
        gameObject.AddComponent<Movement>();
        gameObject.AddComponent<LivingBeing>();

        setSpeed(Random.Range(0.75f, 1.25f));
    }

    private void Update()
    {
        Movement movement = this.GetComponent<Movement>();
        if (target)
        {
            movement.Move(target, getSpeed(), 1);
        }



    }



}
