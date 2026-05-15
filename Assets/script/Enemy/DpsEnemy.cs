using UnityEngine;

public class DpsEnemy : MonoBehaviour
{
    [Header("Attack Parameters")]
    [SerializeField] private float attackCooldown;

    [Header("Collider Parameters")]
    [SerializeField] private Collider2D boxCollider;

    [Header("Paramètre de détection")]
    public Vector2 boxSize = new Vector2(1f, 1f);
    public float castDistance = 2f;
    private RaycastHit2D hit;

    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;

    private float cooldownTimer = Mathf.Infinity;

    private Animator anim;
    public HealthManager myHpManager;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        myHpManager = GetComponent<HealthManager>();
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                anim.SetTrigger("DPSAttack");
            }
        }
    }
    private bool PlayerInSight()
    {
        float directionMultiplier = transform.localScale.x > 0 ? 1f : -1f;
        Vector2 direction = Vector2.right * directionMultiplier;
        hit = Physics2D.BoxCast(transform.position, boxSize, 0f, direction, castDistance, playerLayer);

        if (hit.collider != null)
        {
            Debug.Log("joueur détecté devant" + hit.collider.name);

        }
        return (hit.collider != null);
    }
    private void OnDrawGizmos()
    {
        float directionMultiplier = transform.localScale.x > 0 ? 1f : -1f;
        Vector2 direction = Vector2.right * directionMultiplier;
        Gizmos.color = hit.collider != null ? Color.red : Color.green;
        Gizmos.DrawWireCube((Vector2)transform.position + (direction * castDistance), boxSize);
    }
}
