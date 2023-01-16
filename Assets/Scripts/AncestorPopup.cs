using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AncestorPopup : MonoBehaviour
{
    public Waypoint waypoint;
    public Vector3 offset;
    public GameObject ancestorPrefab;

    // Start is called before the first frame update
    void Start()
    {
        waypoint.OnEndReached += ShowAncestor;
    }

    private void ShowAncestor(Vector3 position)
    {
        SmartPhone.instance.Setup(this);
        ancestorPrefab.SetActive(true);
        ancestorPrefab.transform.localPosition += offset;

        ancestorPrefab.transform.LookAt(Player.Instance.transform);
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
