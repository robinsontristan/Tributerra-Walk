using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartPhone : MonoBehaviour
{
    public static SmartPhone instance;
    private AudioSource audioSource;
    [SerializeField] private List<AudioClip> phoneSounds = new List<AudioClip>();
    private Coroutine phoneCoroutine = null;


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
        }

    }

    public Coroutine PhoneNotification(AudioClip clip)

    {
        if (phoneCoroutine != null)
        {
            StopCoroutine(phoneCoroutine);
        }
        phoneCoroutine = StartCoroutine(PlayAudio(clip, clip.length));
        return phoneCoroutine;


    }

    public IEnumerator  PlayAudio(AudioClip clip, float waittime)
    {
        audioSource.PlayOneShot(clip);
        yield return new WaitForSeconds(waittime);
        StopAudio();

    }

    public void StopAudio()
    {
        if(phoneCoroutine == null)
        {
            return;
        }

        if(audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        if(phoneCoroutine != null)
        {
            StopCoroutine(phoneCoroutine);
        }

        phoneCoroutine = null;
    }
}
