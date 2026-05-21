using UnityEngine;

public class Tyhagan_test : MonoBehaviour
{
    [Header("Attack Parameters")]
    [SerializeField] private float attackCooldown;

    [Header("Collider Parameters")]
    [SerializeField] private Collider2D boxCollider;

    private float cooldownTimer = Mathf.Infinity;

    private Animator anim;
    public HealthManager myHpManager;


    private EnemyPatrol enemyPatrol;

    private void Awake()
    {
        anim = GetComponentInParent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
        myHpManager = GetComponentInParent<HealthManager>();
    }



    private void Update()
    {
        cooldownTimer += Time.deltaTime;
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("joueur détecté devant");
            enemyPatrol.enabled = false;
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                anim.SetTrigger("attack");
            }
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        enemyPatrol.enabled = true;
        
        //Arreter l'attque
        
    }
}
