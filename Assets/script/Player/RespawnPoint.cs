using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    [SerializeField]
    private bool isFirstCheckPoint;

    private void Start()
    {
        if(isFirstCheckPoint)
        {
            FindFirstObjectByType<HM_BackToRespawn>().lastRespawn = this;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        var backToRespawn = other.GetComponent<HM_BackToRespawn>();
        if (backToRespawn!=null)
        {
            backToRespawn.lastRespawn = this;
        }
    }
}