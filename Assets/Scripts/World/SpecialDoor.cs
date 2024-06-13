using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialDoor : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    private bool isOpened = false;
    public Timer timer;
    public float timerDuration = 30f;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isOpened)
        {
            animator.SetTrigger("Opened");
            isOpened = true;
            if (timer != null)
            {
                timer.StartTimer(timerDuration);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && isOpened)
        {
            animator.SetTrigger("Closed");
            isOpened = false;
        }
    }
}
