using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using DG.Tweening;


public class PocketHelper : MonoBehaviour
{
    [SerializeField]
    private float startAnimationDuration = 0.2f;

    [SerializeField]
    private float endAnimationDuration = 0.1f;

    [SerializeField]
    private float scaleAnimationSize = 0.5f;

    private Vector3 startScale;


    // Start is called before the first frame update
    void Start()
    {
        startScale = transform.localScale;
    }

    public void DoScaleUp()
    {
        transform.DOScale(scaleAnimationSize, startAnimationDuration);
    }

    public void DoScaleDown()
    {
        transform.DOScale(startScale, endAnimationDuration);
    }

}
