using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : Animal
{

    public bool Move(GameObject target, float normalSpeed, float run)
    {
        float distance = Vector3.Distance(this.transform.position, target.transform.position);

        while (true)
        {
            Vector3.RotateTowards(this.transform.rotation.eulerAngles, target.transform.rotation.eulerAngles, run * normalSpeed * Time.deltaTime, 0f);
            Vector3.MoveTowards(this.transform.position, target.transform.position, normalSpeed * run * Time.deltaTime);

            if (distance >= 10f && target.tag == "Animal")
            {
                break;
            }

            if (distance < 0.1 && (target.tag == "Plant" || target.tag == "Target"))
            {
                break;
            }
        }
        return true;

    }
}
