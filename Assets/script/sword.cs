using Unity.VisualScripting;
using UnityEngine;

public class sword : MonoBehaviour
{
    public int dammage;
    public SpriteRenderer playerSpriteRenderer;
    public Rigidbody2D Rb;
    

    private void OnTriggerEnter2D(Collider2D triger)
        {
            ennemy1 trigerEnemyComponent = triger.gameObject.GetComponent<ennemy1>();

            if (trigerEnemyComponent != null)
            {
                trigerEnemyComponent.myHpManager.Dammage(dammage, DammageType.Sword);
            }
        }
}
