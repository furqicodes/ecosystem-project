using UnityEngine;

public class Movement : RandomPosition
{
    private float distance = Mathf.Infinity;



    public void Move(GameObject target, float normalSpeed, float run)
    {
        Vector3 targetDir = target.transform.position - this.transform.position;
        Vector3 newDir = Vector3.RotateTowards(this.transform.forward, targetDir, 10f * Time.deltaTime, 0.0f);
        Debug.DrawLine(this.transform.position + new Vector3(0, 0.5f, 0), target.transform.position, Color.red);


        //getRandomPosition(GameObject.Find("gameManager").GetComponent<World>().getWorldScale());

        if (target.tag == "Plant" && this.getDistance(target) > 0.9f)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, target.transform.position, normalSpeed * run * Time.deltaTime);
            this.transform.rotation = Quaternion.LookRotation(newDir);
        }

    }

    public float getDistance(GameObject target)
    {
        distance = Vector3.Distance(this.transform.position, target.transform.position);
        return distance;
    }
}
