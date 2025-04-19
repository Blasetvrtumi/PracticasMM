using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;

public class VuMarkIdManager : MonoBehaviour
{
    private VuMarkBehaviour m_VuMarkBehaviour;
    public Text txtId;
    public Text txtDescripcion;
    public UnityEngine.UI.Image imgVuMark;
    public GameObject[] arrayObjetos;
    private int valorVuMark;
    private int valorObjeto;

    void Start()
    {
        // Comprueba si hay un VuMarkBehaviour en la escena antes de asignarlo
        m_VuMarkBehaviour = Object.FindAnyObjectByType<VuMarkBehaviour>();

        if (m_VuMarkBehaviour == null)
        {
            Debug.LogError("VuMarkBehaviour no encontrado en la escena. Asegúrate de agregar un VuMark.");
            return;  // Evita que el script siga ejecutándose con un objeto `null`
        }

        // Se suscribe a eventos de detección y pérdida de VuMarks
        m_VuMarkBehaviour.OnTargetStatusChanged += OnVuMarkStatusChanged;

        // Inicializa todos los objetos desactivados
        foreach (var obj in arrayObjetos)
        {
            if (obj != null)  // Evita errores si hay objetos `null` en el array
            {
                obj.SetActive(false);
            }
        }

        txtId.text = "";
        imgVuMark.sprite = null;
        txtDescripcion.text = "";
    }

    private void OnVuMarkStatusChanged(ObserverBehaviour behaviour, TargetStatus targetStatus)
    {
        if (targetStatus.Status == Status.TRACKED || targetStatus.Status == Status.EXTENDED_TRACKED)
        {
            OnVuMarkDetected(m_VuMarkBehaviour);
        }
        else
        {
            OnVuMarkLost();
        }
    }

    private void OnVuMarkDetected(VuMarkBehaviour vumark)
    {
        if (vumark == null) return;

        txtId.text = GetVuMarkId(vumark);
        imgVuMark.sprite = GetVuMarkImage(vumark);
        txtDescripcion.text = GetNumericVuMarkDescription(vumark);

        if (int.TryParse(GetVuMarkId(vumark), out valorVuMark))
        {
            for (int i = 0; i < arrayObjetos.Length; i++)
            {
                if (arrayObjetos[i] != null && arrayObjetos[i].name == valorVuMark.ToString())
                {
                    arrayObjetos[i].SetActive(true);
                    valorObjeto = i;
                    break;
                }
            }
        }
    }

    private void OnVuMarkLost()
    {
        txtId.text = "";
        imgVuMark.sprite = null;
        txtDescripcion.text = "";

        if (arrayObjetos.Length > valorObjeto && arrayObjetos[valorObjeto] != null)
        {
            arrayObjetos[valorObjeto].SetActive(false);
        }
    }

    private string GetVuMarkId(VuMarkBehaviour vumark)
    {
        if (vumark.InstanceId == null) return string.Empty;

        switch (vumark.InstanceId.DataType)
        {
            case InstanceIdType.STRING:
                return vumark.InstanceId.StringValue;
            case InstanceIdType.NUMERIC:
                return vumark.InstanceId.NumericValue.ToString();
            default:
                return string.Empty;
        }
    }

    private Sprite GetVuMarkImage(VuMarkBehaviour vumark)
    {
        if (vumark.InstanceImage == null)
        {
            Debug.Log("La instancia de la imagen del VuMark no existe.");
            return null;
        }

        Texture2D texture = new Texture2D(vumark.InstanceImage.Width, vumark.InstanceImage.Height, TextureFormat.RGBA32, false)
        {
            wrapMode = TextureWrapMode.Clamp
        };
        vumark.InstanceImage.CopyToTexture(texture);

        return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
    }

    private string GetNumericVuMarkDescription(VuMarkBehaviour vumark)
    {
        if (int.TryParse(GetVuMarkId(vumark), out int vuMarkIdNumeric))
        {
            switch (vuMarkIdNumeric)
            {
                case 1:
                    return "Taza";
                case 2:
                    return "Arbol";
                case 3:
                    return "Coche";
                default:
                    return "-ERROR-";
            }
        }
        return string.Empty;
    }
}