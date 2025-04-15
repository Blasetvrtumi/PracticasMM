using UnityEngine;

public class MicroDetect : MonoBehaviour
{
    public AudioClip holaClip;
    public float sensibilidad = 0.02f;

    private string micName;
    private AudioClip micClip;
    private AudioSource holaSource;
    private bool haHablado = false;

    void Start()
    {
        if (Microphone.devices.Length == 0)
        {
            Debug.LogError("No hay micrófonos disponibles");
            return;
        }

        micName = Microphone.devices[0];
        micClip = Microphone.Start(micName, true, 1, 44100);

        holaSource = gameObject.AddComponent<AudioSource>();
        holaSource.playOnAwake = false;
    }

    void Update()
    {
        if (haHablado || !Microphone.IsRecording(micName)) return;

        float maxVol = GetMaxMicVolume();

        if (maxVol > sensibilidad)
        {
            haHablado = true;
            holaSource.PlayOneShot(holaClip);
            Invoke(nameof(ReiniciarDetección), holaClip.length + 0.5f);
        }
    }

    float GetMaxMicVolume()
    {
        if (micClip == null) return 0f;

        int micPos = Microphone.GetPosition(micName);
        if (micPos < 256) return 0f;

        float[] samples = new float[256];
        micClip.GetData(samples, micPos - 256);

        float max = 0f;
        foreach (var s in samples)
        {
            float abs = Mathf.Abs(s);
            if (abs > max) max = abs;
        }
        return max;
    }

    void ReiniciarDetección()
    {
        haHablado = false;
    }
}
