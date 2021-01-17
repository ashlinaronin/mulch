using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedalBike : MonoBehaviour
{
    public float speed = 100.0f;

    void Update()
    {
        this.transform.Rotate(0, 0, -Time.deltaTime * speed);
    }
}
