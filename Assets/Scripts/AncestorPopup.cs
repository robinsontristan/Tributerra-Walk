using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AncestorPopup : MonoBehaviour
{
    public Waypoint waypoint;
    public Vector3 offset;
    public GameObject ancestorPrefab;
    public AudioClip ancestorClip;
    public AudioClip ancestorRing;
    
    void Start()
    {
        waypoint.OnEndReached += ShowAncestor;
        HideAncestor();
    }

    private void ShowAncestor(Vector3 position)
    {
        ancestorPrefab.transform.localPosition += offset;
        ancestorPrefab.transform.LookAt(Player.Instance.transform);

        SmartPhone.instance.Setup(this);
        ancestorPrefab.SetActive(true);
        SmartPhone.instance.PhoneNotification(ancestorRing);
        StartCoroutine(PlayAncestorClip(ancestorRing.length));


    }

     
    private IEnumerator PlayAncestorClip (float wait)
    {
        yield return new WaitForSeconds(wait);

        // play smart phone audio
        SmartPhone.instance.PhoneNotification(ancestorClip);

    }
    private void HideAncestor()
    {
        ancestorPrefab.SetActive(false);
    }
    private void OnDestroy()
    {
        waypoint.OnEndReached -= ShowAncestor;
    }

    
}
