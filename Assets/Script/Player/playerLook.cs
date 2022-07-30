using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLook : MonoBehaviour
{
    public Camera cam;
    private float xRotation=0f;
    
    public float Xsensitivity =30f;
    public float Ysensitivity=30f;
    public void ProcessLook(Vector2 input)
    {
        float mouseX=input.x;
        float mouseY=input.y;
        xRotation -= (mouseY*Time.deltaTime) * Ysensitivity;
        xRotation = Mathf.Clamp(xRotation,-80f,80f);
        cam.transform.localRotation=Quaternion.Euler(xRotation,0,0);

        transform.Rotate(Vector3.up*(mouseX*Time.deltaTime)*Xsensitivity);
    }
}
