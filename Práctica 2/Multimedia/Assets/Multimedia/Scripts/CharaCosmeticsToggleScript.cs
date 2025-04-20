using UnityEngine;

public class BotonTeletransportador : MonoBehaviour
{
    public GameObject objetoControlado;

    private bool visible = true;
    private Vector3 posicionOriginal;

    void OnMouseDown()
    {
        visible = !visible;

        if (objetoControlado != null)
        {
            if (visible)
            {
                // Restaurar la posición original
                objetoControlado.transform.localPosition = posicionOriginal;
            }
            else
            {
                posicionOriginal = objetoControlado.transform.localPosition;
                // Mandarlo lejos sin romper jerarquía ni animaciones
                objetoControlado.transform.localPosition = new Vector3(9999, 9999, 9999);
            }
        }
    }
}
