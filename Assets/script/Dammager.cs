using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class Dammager : MonoBehaviour
{
    public int dammage;
    public DammageType type;
    private void OnTriggerEnter2D(Collider2D triger)
    {
        HealthManager otherHp = triger.gameObject.GetComponent<HealthManager>();

        if (otherHp != null)
        {
            otherHp.Dammage(dammage,type);
        }

    }

}
