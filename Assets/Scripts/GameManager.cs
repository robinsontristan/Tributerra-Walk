using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Transform trailPrefab;
    public Transform trailDestination;
    public Transform xrRigTransform;
    public InputAction testInput;
    private TrailMovement trailMovement;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        trailMovement = trailPrefab.GetComponent<TrailMovement>();
        testInput.Enable();

        testInput.performed += context => trailMovement.DrawPath(xrRigTransform, trailDestination);
    }

    public void PlayClip(AudioClip clip, AudioSource source)
    {
        if (source && clip)
        {
            source.PlayOneShot(clip);
        }
    }
}
