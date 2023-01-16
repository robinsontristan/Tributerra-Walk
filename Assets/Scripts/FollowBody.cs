using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBody : MonoBehaviour
{
    public Transform followTransform;
    public Vector3 offset = new Vector3(0, 0, 0.25f);
    public float rotateSpeed;
    public float movementSmoothing;
    private Vector3 velocity = Vector3.zero;
    private Transform cameraTransform;
    private Transform _followTransform;
    private Transform _originalParent;
    private Transform _cameraOffset;
    

    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.transform;

        _originalParent = transform.parent;
        _followTransform = new GameObject().transform;
        _followTransform.name = "Rotation Reference Object";
        _followTransform.position = transform.position;
        _followTransform.rotation = transform.rotation;

        if(_followTransform)
        {
            _followTransform.parent = followTransform;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        UpdateInventoryPosition();
    }

    private void UpdateInventoryPosition()
    {
        if(cameraTransform == null && GameObject.FindGameObjectWithTag("MainCamera") != null)
            {
                cameraTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
            }

        if(cameraTransform == null)
        {
            return;
        }
        Vector3 WorldOffset = Vector3.zero;
        if(followTransform)
        {
            WorldOffset = followTransform.position - followTransform.TransformVector(offset);
        }
        Vector3 MoveToPosition = new Vector3(WorldOffset.x, cameraTransform.position.y - offset.y, WorldOffset.z);
        transform.position = Vector3.SmoothDamp(transform.position, MoveToPosition, ref velocity, movementSmoothing);
        transform.rotation = Quaternion.Lerp(transform.rotation, _followTransform.rotation, Time.deltaTime * rotateSpeed);
    }
}
