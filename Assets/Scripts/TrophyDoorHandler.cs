using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrophyDoorHandler : MonoBehaviour
{

    private Animator animator = null;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.CompareTag("Player"))
        {
            animator.SetBool("isOpen", true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform.parent.CompareTag("Player"))
        {
            animator.SetBool("isOpen", false);
        }
    }
}
