using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

public abstract class Interactable : MonoBehaviour
{
    public bool useEvents;
    [SerializeField]
    public string promptMessage;

    public virtual string OnLook()
    {
        return promptMessage;
    }
    public void BaseInteract()
    {
        if (useEvents)
        {
            InteractionEvent interactionEvent = GetComponent<InteractionEvent>();
            if (interactionEvent != null && interactionEvent.OnInteract != null)
            {
                interactionEvent.OnInteract.Invoke();
            }
        }

        Interact();
    }
    protected virtual void Interact()
    {
        // Initialization code can go here if needed
    }
}
