using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioClip clip;
    public GameManager gameManager;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.Play();
    }

    void Update()
    {
        if (gameManager.isGameOver == true)
        {
            audioSource.Stop();
        }
    }
}
