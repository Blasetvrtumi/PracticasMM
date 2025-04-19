using UnityEngine;

public class PlaySoundInteraction : MonoBehaviour
{
    [SerializeField] private AudioClip soundToPlay;
    [SerializeField] private AudioSource audioSource;

    private void OnMouseDown()
    {
        if (audioSource != null && soundToPlay != null)
        {
            audioSource.clip = soundToPlay;
            audioSource.Play();
        }
    }
}
