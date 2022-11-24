using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedWindow : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetTrigger("Show");
    }

    public void Close()
    {
        _animator.SetTrigger("Hide");
    }
    
    public virtual void OnCloseAnimationComplete()
    {
        Destroy(gameObject);
    }
}
