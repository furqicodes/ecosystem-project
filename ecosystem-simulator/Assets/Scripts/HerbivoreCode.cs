using UnityEngine;

public class HerbivoreCode : MonoBehaviour
{
    private Renderer render;


    void Start()
    {
        render = this.GetComponent<Renderer>();
        // pick a random color
        float k = Random.Range(0.40f, 0.60f);
        Color newColor = new Color(k, k, k, 1.0f);
        // apply it on current object's material
        render.material.color = newColor;
    }


    void Update()
    {



    }
}
