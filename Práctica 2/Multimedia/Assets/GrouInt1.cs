using UnityEngine;
using TMPro;

public class GrouInt1 : MonoBehaviour
{

    public GameObject item;
    public TMP_Text texto; // Use TMP_Text for TextMeshPro

    public void OnMouseOver()
    {
        Debug.Log("Item clicked!");
        // Check if the item is not null before trying to access its properties
        if (texto != null)
        {
            string materialName = item.GetComponent<Renderer>().material.name.Replace(" (Instance)", ""); // Get the material name and remove " (Instance)"
            // Change text content to the material name
            texto.text = materialName;
            Debug.Log(item.GetComponent<Renderer>().material); // Assuming getMaterials() returns a string or some other value
        }
        else
        {
            Debug.LogWarning("Item is null!");
        }
    }

    public void OnMouseExit()
    {
        // Check if the item is not null before trying to access its properties
        if (texto != null)
        {
            texto.text = ""; // Clear the text when the mouse exits
        }
        else
        {
            Debug.LogWarning("Item is null!");
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("OnMouseDown", 0f);
        texto.text = ""; // Desactiva el objeto al inicio
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
