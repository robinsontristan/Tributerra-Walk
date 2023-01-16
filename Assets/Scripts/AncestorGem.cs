using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AncestorGem : MonoBehaviour
{
    [SerializeField]
    private Renderer gemRenderer;
    private Color gemColor;
    [SerializeField]
    private GameObject waypointParent;
    [SerializeField]
    private WillOfAWhisp willOfAWhisp;

    // Start is called before the first frame update
    void Awake()
    {
        gemColor = gemRenderer.GetComponent<Material>().color;
    }

    public void ChangeColor()
    {
        Gradient newGradient = new Gradient();
        GradientColorKey[] colorKey = new GradientColorKey[2];
        colorKey[0].color = gemColor;
        colorKey[1].color = gemColor;
        GradientAlphaKey[] alphaKey = new GradientAlphaKey[2];
        alphaKey[0].alpha = 1f;
        alphaKey[1].alpha = 1f;

        newGradient.SetKeys(colorKey, alphaKey);

        var main = willOfAWhisp.GetComponent<ParticleSystem>().main;
        main.startColor = gemColor;
    }
}
