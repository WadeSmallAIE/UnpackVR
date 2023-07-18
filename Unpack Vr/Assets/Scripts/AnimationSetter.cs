using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;
using Unity.VisualScripting;

public class AnimationSetter : MonoBehaviour
{
    public bool isOpen = false;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        if(isOpen) 
        {
            animator.Play("Close");
            isOpen = false;
        }
        else
        {
            animator.Play("Open");
            isOpen = true;
        }
    }

}
