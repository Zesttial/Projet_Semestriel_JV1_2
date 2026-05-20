using UnityEngine;
using System.Collections;

public class TihaganPattern : MonoBehaviour
{
    [Header("Configuration des Patterns")]
    public float timeBetweenAttacks = 3f;
    private bool isAttacking = false;

    [Header("Références pour les Attaques")]
    public Transform player;
    //public Transform firePoint;
    public Rigidbody2D rb;

    //[Header("Paramètres Projectiles")]
    //public GameObject projectilePrefab;
    //public float projectilesSpeed = 10f;

    //[Header("Paramètre Onde de Choc (AoE")]
    //public GameObject AoEPrefab;

    [Header("Paramètres Dash")]
    public float dashForce = 25f;
    public float dashDuration = 0.5f;

    [Header("Paramètre Espadon")]
    public GameObject espadonHitbox;
    public float swordActiveTime = 0.3f;

    public Animator anim;

    private void Start()
    {
        StartCoroutine(AttackLoop());
        anim = GetComponent<Animator>();
    }

    IEnumerator AttackLoop()
    {
        yield return new WaitForSeconds(timeBetweenAttacks);

        while (true)
        {
            if (!isAttacking)
            {
                isAttacking = true;
                int randomPattern = Random.Range(1, 3);
                //if (randomPattern == 1)
                //    SpawProjectileEvent();
                //else if (randomPattern == 2)
                //    ExecuteAoE();
                if (randomPattern == 1)
                    ExecuteDash();
                else if (randomPattern == 2)
                    ExecuteEspadonAttack();
                yield return new WaitForSeconds(timeBetweenAttacks);
                isAttacking = false;
            }
            yield return null;
        }

    }


    void ExecuteDash()
    {
        anim.SetTrigger("Dash");

        if (player == null || rb == null)
            return;

        Debug.Log("BOSS PATTERN 2 : Dash et frappe à l'issue sur le joueur !");

        StartCoroutine(DashRoutine());
    }

    IEnumerator DashRoutine()
    {
        Vector3 dashDirection = (player.position - transform.position).normalized;
        dashDirection.y = 0;

        rb.linearVelocity = dashDirection * dashForce;

        yield return new WaitForSeconds(dashDuration);

        rb.linearVelocity = Vector3.zero;

    }

    void ExecuteEspadonAttack()
    {
        anim.SetTrigger("attack");

        if (espadonHitbox == null)
            return;

        Debug.Log("Grand coup d'espadon !");

        StartCoroutine(EspadonSlashRoutine());
    }

    IEnumerator EspadonSlashRoutine()
    {
        espadonHitbox.SetActive(true);

        GetComponent<Animator>().SetTrigger("EspandonAttack");

        yield return new WaitForSeconds(swordActiveTime);

        espadonHitbox.SetActive(false);
    }
}
