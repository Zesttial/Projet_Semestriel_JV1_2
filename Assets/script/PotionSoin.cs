using UnityEngine;

public class PotionSoin : MonoBehaviour
{
    public int heal;
    [SerializeField]

    private void OnTriggerEnter2D(Collider2D triger)
    {
        HealthManager otherHp = triger.gameObject.GetComponent<HealthManager>();

        if (otherHp != null)
        {
            otherHp.ChangeHP(heal);
        }

    }
    private void Update()
    {

    }
}
