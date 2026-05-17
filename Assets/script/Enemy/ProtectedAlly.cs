using UnityEngine;

public class ProtectedAlly : MonoBehaviour
{
    [Header("Statut")]
    public bool isPortected = true;
    
    public void TakeDamage(float damage)
    {
        if (isPortected)
        {
            Debug.Log("l'allié est protégé par le Golem! les attaques ricochent.");
            return;
        }

        Debug.Log("l'allié prend des dégâts !");
    }

    public void ExplodeAndDie()
    {
        Debug.Log("Le protecteur est mort, l'allié meut aussi !");
        Destroy(gameObject);
    }
}
