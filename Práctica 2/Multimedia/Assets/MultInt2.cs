using UnityEngine;

public class MultInt2 : MonoBehaviour
{

    public GameObject particles;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (particles != null)
        {
            particles.SetActive(false); // Desactiva el objeto al inicio
        }
    }

    public void OnMouseDown()
    {
        if (particles != null)
        {
            particles.SetActive(!particles.activeSelf); // Alterna la visibilidad del objeto
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
