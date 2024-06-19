using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sway2 : MonoBehaviour
{
    [SerializeField]
    private float SwayAmount = .5f;
    [SerializeField]
    private float smoothness = 2f;

    private Quaternion intialRot;
    private Transform cam;

    private void Start()
    {
        cam = Camera.main.transform;
        intialRot = transform.localRotation;
    }

    private void Update()
    {

        float inputX = -Input.GetAxisRaw("Mouse X") * SwayAmount;
        float inputY = -Input.GetAxisRaw("Mouse Y") * SwayAmount;

        Quaternion targetRot = Quaternion.Euler(inputX, inputY, 0f) * intialRot;
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRot, Time.deltaTime * smoothness);
    }
}
