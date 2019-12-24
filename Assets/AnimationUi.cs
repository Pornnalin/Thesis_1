using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationUi : MonoBehaviour
{
    public GameObject uiAnim;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("IsmoveIn",true);
        anim.SetBool("IsmoveOut", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("IsmoveOut", true);
            anim.SetBool("IsmoveIn", false);
        }
    }
}
