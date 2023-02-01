using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartPhone : MonoBehaviour
{
    public static SmartPhone instance;
    private AudioSource audioSource;
    [SerializeField] private List<AudioClip> phoneSounds = new List<AudioClip>();
    public AncestorPopup Ancestor
    {
        get;
        set;
    }
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void Setup(AncestorPopup newAncestor)
    {
        if(newAncestor)
        {
            Ancestor = newAncestor;
            PhoneNotification();
        }

    }

    private void PhoneNotification( )
    {
        GameManager.instance.PlayClip(phoneSounds[0], audioSource);
    }

    public void PlayAudio(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
