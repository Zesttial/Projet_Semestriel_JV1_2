using UnityEngine;

public class Interactable : MonoBehaviour
{
    public InteractionManager player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player = collision.GetComponent<InteractionManager>();
        if (player != null)
        {
            player.currentInteractable = this;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        player = collision.GetComponent<InteractionManager>();
        if (player != null)
        {
            if (player.currentInteractable == this)
            {
                player.currentInteractable = null;
            }
        }
    }

    public virtual void Interaction()
    {
        print("prout");
    }
}
