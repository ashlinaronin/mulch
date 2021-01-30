using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionToButtScene : MonoBehaviour
{
    // todo: make generic?
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.CompareTag("Player"))
        {
            StartCoroutine(LoadButtSceneAsync());
        }
    }

    IEnumerator LoadButtSceneAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Scenes/InsideButtScene");

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
