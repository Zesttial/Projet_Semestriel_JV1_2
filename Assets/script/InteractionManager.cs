using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public Interactable currentInteractable;
    void Update()
    {
        if (currentInteractable != null)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                currentInteractable.Interaction();
            }
        }
    }
}
