using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour
{   
    private Playerinput playerinput;
    public Playerinput.OnfootActions onfoot;
    private Playermotor motor;
    private playerLook look;
    void Awake()
    {
        playerinput=new Playerinput();
        onfoot=playerinput.Onfoot;

        motor=GetComponent<Playermotor>();
        look=GetComponent<playerLook>();

        onfoot.Jump.performed +=ctx=> motor.Jump();
        onfoot.Crouch.performed +=ctx=> motor.Crouch();
        onfoot.Sprint.performed +=ctx=> motor.Sprint();
    } 

    void FixedUpdate()
    {
        motor.ProcessMove(onfoot.movement.ReadValue<Vector2>());
    }
    private void LateUpdate() 
    {
        look.ProcessLook(onfoot.Look.ReadValue<Vector2>());
    }
    private void OnEnable() 
    {
        onfoot.Enable();
    }
    
    private void OnDisable() 
    {
        onfoot.Disable();
    }
}
