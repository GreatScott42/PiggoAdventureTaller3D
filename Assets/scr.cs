using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr : MonoBehaviour
{
    // Start is called before the first frame update
    Quaternion ogrot;
    Animator animator;

    void Start()
    {
        ogrot = transform.rotation;
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //transform.RotateAround(transform.parent.transform.position, Vector3.down, 50f);
            animator.SetBool("ataque", true);
        }
        else
        {
            //transform.rotation = ogrot;
            animator.SetBool("ataque", false);
        }
    }
}
