using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressMoving1 : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void TurnOffPress()
    {
        _animator.SetBool("isPressActive", false);
    }   
}
