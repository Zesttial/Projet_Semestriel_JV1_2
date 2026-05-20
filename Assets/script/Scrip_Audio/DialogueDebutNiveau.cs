using UnityEngine;

public class DialogueDebutNiveau : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip maReplique;
    public float delaiAvantLancement = 0.5f;

    private void Start()
    {
        if(maReplique != null && audioSource != null)
        {
            Invoke("JouerVoix", delaiAvantLancement);
        }
    }

    void JouerVoix()
    {
        audioSource.PlayOneShot(maReplique);
    }
}
