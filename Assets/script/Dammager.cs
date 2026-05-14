using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Dammager : MonoBehaviour
{
    public int dammage;
    public DammageType type;
    public cooldown Cooldown;

    private void OnTriggerEnter2D(Collider2D triger)
    {
        HealthManager otherHp = triger.gameObject.GetComponent<HealthManager>();

        if (otherHp != null & Cooldown.Cooldown <= 0)
        {
            otherHp.Dammage(dammage,type);
            Cooldown.Cooldown = 2;

        }

    }
    private void Update()
    {
        if (Cooldown.Cooldown > 0)
        {
            Cooldown.Cooldown -= Time.deltaTime;
        }
    }

}
