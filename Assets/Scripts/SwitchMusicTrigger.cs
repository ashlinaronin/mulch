using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMusicTrigger : MonoBehaviour
{
    public AudioClip newTrack;
    private AudioManager audioManager;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (newTrack == null) return;

        if (other.transform.parent.CompareTag("Player"))
        {
            audioManager.ChangeBackgroundMusic(newTrack);
        }
    }
}
