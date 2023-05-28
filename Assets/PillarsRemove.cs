using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarsRemove : MonoBehaviour
{

    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void RemovePillars()
    {
        animator.SetBool("PillarsDown", true);
    }
}
