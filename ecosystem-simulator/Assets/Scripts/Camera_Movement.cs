using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
    void Awake()
    {
        Camera cam = gameObject.GetComponent<Camera>();
        //Fit camera to terrain
        cam.orthographicSize = GameObject.Find("gameManager").GetComponent<Game_Manager>().worldScale * 5f;
        cam.transform.rotation = Quaternion.Euler(90f, 0, 0);

    }

    void Update()
    {
        transform.Translate(Input.GetAxisRaw("Horizontal") * Time.deltaTime * 5, 0, 0);
        transform.Translate(0, Input.GetAxisRaw("Vertical") * Time.deltaTime * 5, 0);

        if (Input.GetKey(KeyCode.Q))
            gameObject.GetComponent<Camera>().orthographicSize += 5 * Time.deltaTime;

        if (Input.GetKey(KeyCode.E))
            gameObject.GetComponent<Camera>().orthographicSize -= 5 * Time.deltaTime;
    }

}
