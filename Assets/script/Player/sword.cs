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
        if (triger.CompareTag("Enemy"))
        {
            MeleeEnemy trigerEnemyComponent = triger.gameObject.GetComponent<MeleeEnemy>();

            if (trigerEnemyComponent != null)
            {
                trigerEnemyComponent.myHpManager.Dammage(dammage, DammageType.Sword);
            }
        }
    }
}
