using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;
    [SerializeField] GameObject goAdoPre;
    [SerializeField] List<AudioClip> audios;
    [SerializeField] AudioSource[] sources;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        sources = new AudioSource[audios.Count];
    }
    public void Play(int i, float volume = 1)
    {
        Play(audios[i], ref sources[i], volume);
    }

    void Play(AudioClip clip, ref AudioSource audioSource, float volume = 1f, bool isLoopback = false, bool repeat = false)
    {
        if (audioSource != null && audioSource.isPlaying && !repeat)
            return;
        audioSource = Instantiate(instance.goAdoPre).GetComponent<AudioSource>();
        audioSource.volume = volume;
        audioSource.loop = isLoopback;
        audioSource.clip = clip;
        audioSource.Play();
        Destroy(audioSource.gameObject, audioSource.clip.length);
    }

}
