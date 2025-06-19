using System;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    public Animator _animator;

    public void WalkAnimationStatus(bool request)
    {
        _animator.SetBool("Roll_Anim", request);
    }
    
    
}
