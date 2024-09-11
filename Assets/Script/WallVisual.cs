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
    private void OnCollisionEnter(Collision collision)
    {
        if (((1 << collision.gameObject.layer) & targetLayer) != 0)
        {
            animator.SetTrigger("OpenClose");
        }
    }
}
