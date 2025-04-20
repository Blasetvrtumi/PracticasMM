using UnityEngine;

public class MultiInt1 : MonoBehaviour
{

    public GameObject texto;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (texto != null)
        {
            texto.SetActive(false); // Desactiva el objeto al inicio
        }
    }

    private void OnMouseOver()
    {
        if (texto != null)
        {
            texto.SetActive(!texto.activeSelf); // Alterna la visibilidad del objeto
        }
    }

    private void OnMouseExit()
    {
        if (texto != null)
        {
            texto.SetActive(false); // Desactiva el objeto al salir del mouse
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
