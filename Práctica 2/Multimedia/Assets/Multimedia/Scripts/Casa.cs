using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Casa : MonoBehaviour
{
    
    public Slider slideRotacion;
    public Slider slideEscala; // Nuevo slider para la escala
    public GameObject GOAuto;

    public Material[] newColor;
    GameObject[] partesAuto;
    Material[] mats;

    public void rotacion () {
        GOAuto.transform.rotation = Quaternion.Euler (0, slideRotacion.value, 0);

    }

    public void cambiarColor(int color)
    {
        // Verifica si GOAuto tiene un MeshRenderer
        MeshRenderer renderer = GOAuto.GetComponent<MeshRenderer>();
        if (renderer != null)
        {
            // Asigna el material correspondiente de newColor al MeshRenderer
            Material[] mats = renderer.materials;
            if (mats.Length > 0)
            {
                mats[0] = newColor[color];
                renderer.materials = mats;
            }
        }
    }
    public void cambiarEscala()
    {
        // Ajusta la escala de GOAuto en función del valor del slider
        float escala = slideEscala.value;
        GOAuto.transform.localScale = new Vector3(escala, escala, escala);
    }

}
