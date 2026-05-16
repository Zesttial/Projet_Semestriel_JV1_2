using UnityEngine;
using System.Collections;

public class TihaganPattern : MonoBehaviour
{
    [Header("Configuration des Patterns")]
    public float timeBetweenAttacks = 3f;
    private bool isAttacking = false;

    [Header("Références pour les Attaques")]
    public Transform player;
    public Transform firePoint;
    public Rigidbody2D rb;

    [Header("Paramètres Projectiles")]
    public GameObject projectilePrefab;
    public float projectilesSpeed = 10f;

    [Header("Paramètre Onde de Choc (AoE")]
    public GameObject AoEPrefab;

    [Header("Paramètres Dash")]
    public float dashForce = 25f;
    public float dashDuration = 0.5f;

    [Header("Paramètre Espadon")]
    public GameObject espadonHitbox;
    public float swordActiveTime = 0.3f;



    private void Start()
    {
        StartCoroutine(AttackLoop());
    }

    IEnumerator AttackLoop()
    {
        yield return new WaitForSeconds(2f);

        while (true)
        {
            if (!isAttacking)
            {
                isAttacking = true;
                int randomPattern = Random.Range(1, 4);
                if (randomPattern == 1)
                    ExecuteProjectile();
                else if (randomPattern == 2)
                    ExecuteAoE();
                else if (randomPattern == 3)
                    ExecuteDash();
                yield return new WaitForSeconds(timeBetweenAttacks);
                isAttacking = false;
            }
            yield return null;
        }

    }
    void ExecuteProjectile()
    {
        if (player == null || firePoint == null || projectilePrefab == null)
            return;

        Debug.Log("BOSS PATTERN 1 : Rafale de 3 projectiles vers le joueur !");

        GameObject bullet = Instantiate(projectilePrefab, firePoint.position, transform.rotation);

        Vector3 direction = (player.position - firePoint.position).normalized;

        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

        if (bulletRb != null)
        {
            bulletRb.linearVelocity = direction * projectilesSpeed;
        }
    }

    void ExecuteAoE()
    {
        if (AoEPrefab == null)
            return;

        Debug.Log("BOSS PATTERN 3 : Hurlement Pluie de Débris");

        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        GameObject wave = Instantiate(AoEPrefab, spawnPosition, transform.rotation);
    }

    void ExecuteDash()
    {
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

        ExecuteEspadonAttack();
    }

    void ExecuteEspadonAttack()
    {
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
