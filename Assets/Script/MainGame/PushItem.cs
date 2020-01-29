using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]

public class PushItem : MonoBehaviour
{
    public AudioClip soundClip;
    public float obMass = 300;
    public float pushAtMass = 100;
    public float pushingTime;
    public float foreceToPush;
    Rigidbody rigi;
    public float vel;
    AudioSource audioPlyer;
    Vector3 dir;

    Vector3 lastPos;
    float _pushingTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        rigi = GetComponent<Rigidbody>();
        if (rigi == null) return;

        //audioPlyer = GetComponent<AudioSource>();
        //if (soundClip != null)
        //{
        //    audioPlyer.clip = soundClip;
        //    audioPlyer.Stop();
        //}
        //audioPlyer.volume = 0;
        //audioPlyer.pitch = 0.5f;
        rigi.mass = obMass;

    }

    bool IsMoveing()
    {
        if (rigi.velocity.magnitude > 0.06f)
        {
            return true;
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        vel = rigi.velocity.magnitude;
        if (Input.GetKeyUp(KeyCode.F))
        {
            rigi.isKinematic = true;
            //if (soundClip != null)
            //{
            //    audioPlyer.Stop();
            //}

            //audioPlyer.volume = 0f;
            //audioPlyer.pitch = 0.2f;
        }

        if (rigi.isKinematic == false)
        {
            _pushingTime += Time.deltaTime;
            if (_pushingTime >= pushingTime)
            {
                _pushingTime = pushingTime;
            }

            rigi.mass = Mathf.Lerp(obMass, pushingTime, _pushingTime / pushingTime);
            rigi.AddForce(dir * foreceToPush, ForceMode.Force);
        
        }
    }
}
