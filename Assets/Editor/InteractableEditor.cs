using UnityEditor;

[CustomEditor(typeof(Interactable),true)]
public class InteractableEditor : Editor
{
    public override void OnInspectorGUI() 
    {   
        Interactable interactable = (Interactable) target;
        if(target.GetType()==typeof(EventOnlyInteractable))
        {
            interactable.promptMessage = EditorGUILayout.TextField("Prompt Message", interactable.promptMessage);
            EditorGUILayout.HelpBox("EventOnlyInteract can ONLY use UnityEvents.",MessageType.Info);
            if(interactable.GetComponent<Interactevent>() ==null)
            {
                interactable.useEvents = true;
                interactable.gameObject.AddComponent<Interactevent>();
            }
        }
        else
        {
            base.OnInspectorGUI();
            if(interactable.useEvents)
            {   
                if(interactable.GetComponent<Interactevent>()== null)
                {
                    interactable.gameObject.AddComponent<Interactevent>();
                }  
            }
            else
            {
                if(interactable.GetComponent<Interactevent>() != null)
                    DestroyImmediate(interactable.GetComponent<Interactevent>());
            }
        }
        
    }
}
