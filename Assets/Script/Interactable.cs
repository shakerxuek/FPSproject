using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{   
    public bool useEvents;
    public string promptMessage;

    public virtual string Onlook()
    {
        return promptMessage;
    }
    public void BaseInteract()
    {   
        if(useEvents)
            GetComponent<Interactevent>().Oninteract.Invoke();
        Interact();
    }
    protected virtual void Interact()
    {

    }
}
