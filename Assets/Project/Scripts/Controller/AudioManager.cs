using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Clips")]
    [SerializeField] private AudioClip flipClip;
    [SerializeField] private AudioClip matchClip;
    [SerializeField] private AudioClip mismatchClip;
    [SerializeField] private AudioClip gameOverClip;

    [SerializeField] private AudioSource audioSource;
    private Dictionary<string, AudioClip> sounds;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);


            sounds = new Dictionary<string, AudioClip>
            {
                { "Flip", flipClip },
                { "Match", matchClip },
                { "Mismatch", mismatchClip },
                { "GameOver", gameOverClip }
            };
        }

    }
    public void Play(string name)
    {
        if (sounds.ContainsKey(name) && sounds[name] != null)
        {
            audioSource.PlayOneShot(sounds[name]);
        }

    }
}
