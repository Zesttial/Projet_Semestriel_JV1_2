using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Dammager : MonoBehaviour
{
    public int dammage;
    public DammageType type;
    [SerializeField]
    private bool ShouldImmunePlayerToDammge;

    private void OnTriggerEnter2D(Collider2D triger)
    {
        HealthManager otherHp = triger.gameObject.GetComponent<HealthManager>();

        if (otherHp != null )
        {
            otherHp.Dammage(dammage,type);
            if(ShouldImmunePlayerToDammge)
            {
                otherHp.Immunities(type);
            }
        }

    }
    private void Update()
    {

    }

}
