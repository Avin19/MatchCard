using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Clips")]
    public AudioClip flipClip;
    public AudioClip matchClip;
    public AudioClip mismatchClip;
    public AudioClip gameOverClip;

    private AudioSource audioSource;
    private Dictionary<string, AudioClip> sounds;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = gameObject.AddComponent<AudioSource>();

            sounds = new Dictionary<string, AudioClip>
            {
                { "Flip", flipClip },
                { "Match", matchClip },
                { "Mismatch", mismatchClip },
                { "GameOver", gameOverClip }
            };
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Play(string name)
    {
        if (sounds.ContainsKey(name) && sounds[name] != null)
        {
            audioSource.PlayOneShot(sounds[name]);
        }
        else
        {
            Debug.LogWarning($"Sound '{name}' not found or not assigned.");
        }
    }
}
