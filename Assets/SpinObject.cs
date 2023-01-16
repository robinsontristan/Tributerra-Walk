using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinObject : MonoBehaviour
{

    public Transform objectToRotate;
    public float rotationSpeed = 100;

    

    // Update is called once per frame
    void Update()
    {
        objectToRotate.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
        //transform.RotateAround(objectToRotate.transform.position, Vector3.up, 20 * Time.deltaTime);
    }
}
