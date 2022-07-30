using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField]
    private float distance =3f;
    [SerializeField]
    private LayerMask mask;
    private PlayerUI playerUI;
    private InputManager inputManager;
    private void Start() 
    {
        cam=GetComponent<playerLook>().cam;
        playerUI=GetComponent<PlayerUI>();
        inputManager =GetComponent<InputManager>();
    }

    private void Update() 
    {   
        playerUI.UpdateText(string.Empty);
        //create a ray that shooting outwards
        Ray ray =new Ray(cam.transform.position,cam.transform.forward);
        Debug.DrawRay(ray.origin,ray.direction*distance);
        RaycastHit hitInfo;//variable to store collision information
        if(Physics.Raycast(ray, out hitInfo,distance,mask))
        {
            if(hitInfo.collider.GetComponent<Interactable>()!=null)
            {   
                Interactable interactable =hitInfo.collider.GetComponent<Interactable>();
                playerUI.UpdateText(interactable.promptMessage);
                if(inputManager.onfoot.Interact.triggered)
                {
                    interactable.BaseInteract();
                }
            }
        }
    }
}
