using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSound : MonoBehaviour
{

    AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        // don't play sounds for AI (we have a tag of Player set on the Colliders container object)
        if (other.transform.parent.CompareTag("Player"))
        {
            source.Play();
        }
    }
}
