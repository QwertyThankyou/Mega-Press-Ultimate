using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public float speed = 1f;
    public Animator animator;

    void Start()
    {
        
    }
    
    void Update()
    {
        Vector3 target = transform.position;
        target.x += 1f;
        transform.position = Vector3.Lerp(transform.position, target, speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("Crushed");
        }
    }
}
