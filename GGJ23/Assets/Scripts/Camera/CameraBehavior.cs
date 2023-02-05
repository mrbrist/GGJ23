using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        if(Input.GetButton("Shake"))
        {
            Digging();
        }
    }

    void Digging()
    {
        anim.SetTrigger("Shake");
    }
}
