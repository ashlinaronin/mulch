using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioVisualization : MonoBehaviour
{
    AudioSource audioSource;
    Renderer[] childRenderers;

    public int trackNumber;

    public float playedSeconds = 0f;

    public GameObject mainCamera;

    private bool visited = false;

    private const int listeningThreshold = 25;

    private Vector4 startOffset = new Vector4(1f, 0.5f, 0f, 0f);

    // slightly over 0.5 eliminates the seams on either pole of the capsule
    private Vector4 endOffset = new Vector4(1f, 0.5f, 0f, 0.52f);

    [Serializable]
    public class TrackListenedEvent : UnityEvent<int,int>{};

    public TrackListenedEvent secondListened;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        childRenderers = GetComponentsInChildren<Renderer>();
    }

    void Update()
    {
        var isPlayerClose = CheckCloseToCamera(listeningThreshold);

        // if player isn't close, we don't want to do anything else
        if (!isPlayerClose) return;

        // initial visit to this beacon
        if (!visited) {
            visited = true;
        }

        // subsequent frames while listening to this beacon
        if (visited && playedSeconds < audioSource.clip.length) {
            // add the number of seconds since the last frame
            playedSeconds += Time.deltaTime;

            // account for rounding error -- if we are within 1s of fully played, make sure it is tracked as fully played
            if ((float)Math.Ceiling(playedSeconds) == (float)Math.Ceiling(audioSource.clip.length))
            {
                playedSeconds = audioSource.clip.length;
            }

            // call event listened by game logic to keep track of global listened state
            secondListened.Invoke(trackNumber, (int)Math.Ceiling(playedSeconds));
            VisualizeListenedProgress();
        }
    }

    // show progress by moving the UV offset for both children of this GO (minimap beacon and player scale beacon)
    private void VisualizeListenedProgress() {
        float t = playedSeconds / audioSource.clip.length;

        foreach (Renderer childRenderer in childRenderers)
        {
            // _BaseMap_ST is a 4d vector containing tiling and offset (for URP/Lit)
            childRenderer.material.SetVector("_BaseMap_ST", Vector4.Lerp(startOffset, endOffset, t));
        }
    }

    public int GetLength() {
        return audioSource ? (int)Math.Ceiling(audioSource.clip.length) : 0;
    }

    bool CheckCloseToCamera(float minimumDistance)
    {
        return Vector3.Distance(transform.position, mainCamera.transform.position) <= minimumDistance;
    }
}
