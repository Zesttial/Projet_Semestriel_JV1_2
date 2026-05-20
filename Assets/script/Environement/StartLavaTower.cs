using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class StartLavaTower : MonoBehaviour
{
    public Animator laveAnimator;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            laveAnimator.SetTrigger("StartLave");

            Destroy(gameObject);
        }
    }
    
}
