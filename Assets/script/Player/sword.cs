using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class sword : MonoBehaviour
{
    public int dammage;
    public Rigidbody2D Rb;
    public string targetTag;



    private void OnTriggerEnter2D(Collider2D triger)
    {
        if (!triger.CompareTag(gameObject.tag))
        {
            HealthManager trigerEnemyComponent = triger.gameObject.GetComponent<HealthManager>();

            if (trigerEnemyComponent != null)
            {
                trigerEnemyComponent.Dammage(dammage, DammageType.Sword);
            }
        }
    }
}
