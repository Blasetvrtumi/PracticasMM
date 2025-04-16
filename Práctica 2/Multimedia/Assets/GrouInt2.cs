using UnityEngine;

public class GrouInt2 : MonoBehaviour
{
    public GameObject item;
    public AudioClip popClip;

    private AudioSource audioSource;

    public void OnMouseDown()
    {
        Debug.Log("Item clicked!");
        // Check if the item is not null before trying to access its properties
        if (item != null)
        {
            //Play the pop sound
            audioSource.PlayOneShot(popClip);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
