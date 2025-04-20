using UnityEngine;

public class JumpScript : MonoBehaviour
{
    // Objeto que realizará el salto
    public GameObject targetObject;

    // Altura máxima del salto
    public float jumpHeight = 0.1f;

    // Duración del salto (en segundos)
    public float jumpDuration = 0.25f;

    // Rebote (porcentaje de la altura del salto)
    public float bounceFactor = 0.25f;

    private Vector3 originalPosition;
    private bool isJumping = false;
    public void OnButtonPress()
    {
        if (targetObject != null && !isJumping)
        {
            originalPosition = targetObject.transform.position;
            StartCoroutine(JumpSequence());
        }
    }

    private System.Collections.IEnumerator JumpSequence()
    {
        isJumping = true;

        // Movimiento hacia arriba
        float elapsedTime = 0f;
        while (elapsedTime < jumpDuration / 2)
        {
            float progress = elapsedTime / (jumpDuration / 2);
            targetObject.transform.position = Vector3.Lerp(originalPosition, originalPosition + Vector3.up * jumpHeight, progress);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Movimiento hacia abajo
        elapsedTime = 0f;
        while (elapsedTime < jumpDuration / 2)
        {
            float progress = elapsedTime / (jumpDuration / 2);
            targetObject.transform.position = Vector3.Lerp(originalPosition + Vector3.up * jumpHeight, originalPosition, progress);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Rebote
        if (bounceFactor > 0)
        {
            Vector3 bouncePosition = originalPosition + Vector3.up * (jumpHeight * bounceFactor);
            elapsedTime = 0f;
            while (elapsedTime < jumpDuration / 4)
            {
                float progress = elapsedTime / (jumpDuration / 4);
                targetObject.transform.position = Vector3.Lerp(originalPosition, bouncePosition, progress);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            elapsedTime = 0f;
            while (elapsedTime < jumpDuration / 4)
            {
                float progress = elapsedTime / (jumpDuration / 4);
                targetObject.transform.position = Vector3.Lerp(bouncePosition, originalPosition, progress);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
        }

        // Asegurarse de que el objeto regrese exactamente a su posición original
        targetObject.transform.position = originalPosition;

        isJumping = false;
    }
}
