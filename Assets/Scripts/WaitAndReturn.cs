using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaitAndReturn : MonoBehaviour
{
    public string returnSceneName;
    public float waitSeconds = 5;

    void Start()
    {
        StartCoroutine(WaitAndRestartCoroutine());
    }

    IEnumerator WaitAndRestartCoroutine()
    {
        yield return new WaitForSeconds(waitSeconds);
        SceneManager.LoadScene(returnSceneName);
    }
}
