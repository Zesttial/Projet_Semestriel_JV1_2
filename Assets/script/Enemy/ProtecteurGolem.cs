using UnityEngine;

public class ProtecteurGolem : MonoBehaviour
{
    [Header("Santé")]
    public float maxHealth = 150f;
    private float currentHealth;

    [Header("lien de Protection")]
    public ProtectedAlly allyToProtect;

    private Rigidbody2D rb;

    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();

        if(rb != null )
        {
            rb.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;
        }

        Debug.Log("Le Golem est immobile et prootège son allié.");
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log($"Le Golem prend {damage} dégâts.HP restant : {currentHealth}");

        if(currentHealth <= 0 )
        {
            Die();
        }
    }

    void Die()
    {
        if(allyToProtect  != null)
        {
            allyToProtect.ExplodeAndDie();
        }

        Debug.Log("Le Golem Proctecteur s'effondre.");
        Destroy(gameObject);
    }
}
