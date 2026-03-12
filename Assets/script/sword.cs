using UnityEngine;

public class sword : MonoBehaviour
{
    public int dammage;
    public SpriteRenderer playerSpriteRenderer;
    public Rigidbody2D Rb;
 

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ennemy1 collisionEnemyComponent = collision.gameObject.GetComponent<ennemy1>();

        if (collisionEnemyComponent != null)
        {
            collisionEnemyComponent.myHpManager.Dammage(dammage,DammageType.Sword);
        }
    }
    
}
