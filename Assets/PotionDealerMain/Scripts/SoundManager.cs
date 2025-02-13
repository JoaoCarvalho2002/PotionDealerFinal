using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource hello;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hello = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlaySound()
    {
        hello.Play(0);

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Client")
        {
           
            hello.Play(0);
        }
    }
}
