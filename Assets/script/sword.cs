using UnityEngine;

public class sword : MonoBehaviour
{
    public int dammage;
    public SpriteRenderer spriteRenderer;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ennemy1 collisionEnemyComponent = collision.gameObject.GetComponent<ennemy1>();

        if (collisionEnemyComponent != null)
        {
            collisionEnemyComponent.myHpManager.RemoveHp(dammage);
        }
    }
    void Update()
    {
        if (hDirection == -1)
        {

        }
    }
}
