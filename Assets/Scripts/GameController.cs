using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    private int totalSecondsAvailable = 0;
    
    public Dictionary<int,int> trackSecondsPlayed = new Dictionary<int,int>();

    [Serializable]
    public class StringEvent : UnityEvent<string>{};

    public StringEvent updateDisplay;

    void Start()
    {
        var allAudioBeacons = FindObjectsOfType<AudioVisualization>();        
        foreach (AudioVisualization audioBeacon in allAudioBeacons)
        {
            totalSecondsAvailable += audioBeacon.GetLength();
        }
        SetDisplayMessage();
    }

    public void SetTrackSecondsPlayed(int trackNumber, int secondsPlayed)
    {
        trackSecondsPlayed[trackNumber] = secondsPlayed;
        SetDisplayMessage();
    }

    private void SetDisplayMessage() {
        int totalSecondsPlayed = 0;

        foreach (KeyValuePair<int,int> track in trackSecondsPlayed)
        {
            totalSecondsPlayed += track.Value;
        }

        string message = $"{totalSecondsPlayed.ToString()}/{totalSecondsAvailable.ToString()}";
        updateDisplay.Invoke(message);
    }
}
