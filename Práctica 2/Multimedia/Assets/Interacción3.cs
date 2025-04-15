using UnityEngine;

public class BotonesRA : MonoBehaviour
{
    public GameObject gorro;
    public GameObject mochila;

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = cam.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                string nombre = hit.transform.name;

                if (nombre.Contains("BotonGorro"))
                {
                    gorro.SetActive(!gorro.activeSelf);
                    Debug.Log("Gorro toggled: " + gorro.activeSelf);
                }
                else if (nombre.Contains("BotonMochila"))
                {
                    mochila.SetActive(!mochila.activeSelf);
                }
            }
        }
    }
}
