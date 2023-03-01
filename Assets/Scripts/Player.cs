using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Crouch Settings")]
    public InputActionReference crouchButton = null;
    public float crouchHeight = 0.7f;
    public float crouchDuration = 0.75f;
    public Transform cameraOffsetTransform;

    private bool crouch = false;
    private Vector3 crouchPosition;
    public static Player Instance
    {
        get;
        private set;
    }

    public int PlayerWaypointIndex
    {
        get;
        set;
    }

    public int? NextPlayerWaypointIndex
    {
        get;
        set;
    }

    public WillOfAWhisp whisp;

    void Awake()
    {
        if(Instance != null)
        {
            throw new System.Exception($"There are two players in the scene! {Instance} :: {this}");
        }

        Instance = this;

        crouchButton.action.performed += CrouchUncrouch;
    }

    private void OnDestroy()
    {
        crouchButton.action.performed -= CrouchUncrouch;
    }

    private void CrouchUncrouch(InputAction.CallbackContext obj)
    {
        crouch = !crouch;
        
        // TODO: fix crouch!
        if (crouch)
        {
            this.crouchPosition = cameraOffsetTransform.position;
            if(Physics.Raycast(crouchPosition,Vector3.down, out RaycastHit hit))
            {
                Vector3 newCrouchPosition = new Vector3(cameraOffsetTransform.position.x, cameraOffsetTransform.position.y - hit.point.y - crouchHeight, cameraOffsetTransform.position.z);
                StartCoroutine(CrouchUnCrouch(cameraOffsetTransform.position, newCrouchPosition));
            }
            
        }
        else
        {
            Vector3 uncrouch = this.crouchPosition;
            StartCoroutine(CrouchUnCrouch(cameraOffsetTransform.position, uncrouch));
        }
    }

    private IEnumerator CrouchUnCrouch(Vector3 startPosition, Vector3 endPosition)
    {
        float elapsedTime = 0.0f;
        while (elapsedTime <= crouchDuration)
        {
            elapsedTime += Time.deltaTime;
            Vector3 lerpPosition = Vector3.Lerp(startPosition, endPosition, elapsedTime / crouchDuration);
            cameraOffsetTransform.position = lerpPosition;
            yield return new WaitForEndOfFrame();
        }
    }

    public Vector3 PlayerPosition()
    {
        return transform.localPosition;
    }

    public void CalculateAngle()
    {
        
    }


    public void StartPath(Vector3 startPosition, Vector3 endPosition)
    {
        whisp.StartTravel(startPosition, endPosition);
    }
}
