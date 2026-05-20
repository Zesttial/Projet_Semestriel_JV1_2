using UnityEngine;

public class VoiceTrigger : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip maVoix;
    private bool dejaJoue = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !dejaJoue)
        {
            audioSource.PlayOneShot(maVoix);
            dejaJoue = true;
        }
    }
}
