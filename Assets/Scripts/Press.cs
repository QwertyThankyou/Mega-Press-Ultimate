using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Press : MonoBehaviour
{
    public GameController gameController;
    public Animation pressAnimation;
    
    public Animator animator;
    private bool _isPressed = false;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && _isPressed == false)
        {
            _isPressed = true;
            StartCoroutine(Work());
            animator.SetTrigger("Press");
        }
    }

    private IEnumerator Work()
    {
        //yield return new WaitForSeconds(pressAnimaiton.clip.length);
        yield return new WaitForSeconds(1f);
        _isPressed = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        gameController.countCrush++;
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
