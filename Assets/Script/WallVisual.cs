using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallVisual : MonoBehaviour
{
    Animator animator;
    [SerializeField] LayerMask targetLayer;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & targetLayer) != 0)
        {
            animator.SetTrigger("Open");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (((1 << other.gameObject.layer) & targetLayer) != 0)
        {
            animator.SetTrigger("Close");
        }
    }
}
