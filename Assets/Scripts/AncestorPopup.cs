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
    
    void Start()
    {
        waypoint.OnEndReached += ShowAncestor;
        HideAncestor();
    }

    private void ShowAncestor(Vector3 position)
    {
        SmartPhone.instance.Setup(this);
        ancestorPrefab.SetActive(true);
        StartCoroutine(DelayAncestorSound());


        ancestorPrefab.transform.localPosition += offset;

        ancestorPrefab.transform.LookAt(Player.Instance.transform);
    }

    private IEnumerator DelayAncestorSound()
    {
        yield return new WaitForSeconds(2f);

        // play smart phone audio
        SmartPhone.instance.PlayAudio(ancestorClip);

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
