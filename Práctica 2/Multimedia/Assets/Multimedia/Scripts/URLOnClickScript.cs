using UnityEngine;

public class Interacción : MonoBehaviour
{
    public string URL;

    private void OnMouseDown()
    {
        // Abre la URL en el navegador predeterminado
        Application.OpenURL(URL);
    }
}
