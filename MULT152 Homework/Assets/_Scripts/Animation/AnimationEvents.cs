using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    private AudioSource src;
    void Start()
    {
        src = GetComponent<AudioSource>();
    }

    public void playAudio()
    {
        src.Play();
    }
}
