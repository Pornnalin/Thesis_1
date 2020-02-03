using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager soundManager;
    public AudioSource audioS;
    public AudioClip em, walk;


    public enum soundInGame
    {
        em_sound, walk
    }

    public void Awake()
    {
        if (soundManager == null)
        {
            soundManager = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        audioS = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        audioS.volume = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(soundInGame sound)
    {
        switch (sound)
        {
            case soundInGame.em_sound:
                audioS.PlayOneShot(em);
                    break;
        }
    }
}
