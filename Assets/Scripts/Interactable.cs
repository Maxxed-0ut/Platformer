using UnityEngine;

public abstract class Interactable : MonoBehaviour
{

    public string PromptMessage;
    public void OnInteract()
    {
        Interact();
    }
    protected virtual void Interact()
    {
        // Initialization code can go here if needed
    }
}
