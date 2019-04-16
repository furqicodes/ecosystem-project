using System.Collections;
using UnityEngine;

public class Movement : RandomPosition
{
    private float distance = Mathf.Infinity;
    private Vector3 destination = Vector3.zero;
    private Vector3 velocity = Vector3.zero;

    public void Move(GameObject target, float normalSpeed, float run)
    {
        Vector3 targetDir = target.transform.position - this.transform.position;
        Vector3 newDir = Vector3.RotateTowards(this.transform.forward, targetDir, 10f * Time.deltaTime, 0.0f);
        Debug.DrawLine(this.transform.position + new Vector3(0, 0.5f, 0), target.transform.position, Color.red);


        //getRandomPosition(GameObject.Find("gameManager").GetComponent<World>().getWorldScale());

        if (target.tag == "Plant" && this.getDistance(target.transform.position) > 0.9f)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, target.transform.position, normalSpeed * run * Time.deltaTime);
            this.transform.rotation = Quaternion.LookRotation(newDir);
        }

    }

    public void setDestination(Vector3 v)
    {
        this.destination = v;
    }

    public float getDistance(Vector3 target)
    {
        distance = Vector3.Distance(this.transform.position, target);
        return distance;
    }

    public Vector3 getDestination()
    {
        return this.destination;
    }
}
