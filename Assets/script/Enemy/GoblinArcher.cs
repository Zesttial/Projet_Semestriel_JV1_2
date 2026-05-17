using UnityEngine;
using System.Collections;

public class GoblinArcher : MonoBehaviour
{
    [Header("Réglage du timing")]
    public float timeHidden = 3f;
    public float timeVisible = 1.5f;

    [Header("Tir")]
    public GameObject arrowPrefab;
    public Transform firePoint;
    public float arrowSpeed = 8f;

    [Header("Positions (Si pas d'animations")]
    public Vector3 positionCachee;
    public Vector3 positionSortie;

    private bool isDead = false;

    void Start()
    {
        transform.localPosition = positionCachee;
        StartCoroutine(GoblinRoutine());
    }

    IEnumerator GoblinRoutine()
    {
        while (!isDead)
        {
            GetComponent<Animator>().SetTrigger("Sortir");
            yield return new WaitForSeconds(0.3f);

            TirerFleche();

            yield return new WaitForSeconds(timeVisible - 0.3f);
        }
    }

    void TirerFleche()
    {
        if (arrowPrefab == null || firePoint == null) return;

        GameObject arrow = Instantiate (arrowPrefab, firePoint.position, firePoint.rotation);

        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.linearVelocity = firePoint.right * arrowSpeed;
        }
    }

    public void TakeDamage()
    {
        isDead = true;
        StopAllCoroutines();
        Debug.Log("le gobelin est mort !");
        Destroy(gameObject);
    }
}
