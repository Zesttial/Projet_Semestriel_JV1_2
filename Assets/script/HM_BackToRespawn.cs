using UnityEngine;
using UnityEngine.SceneManagement;

public class HM_BackToRespawn : HpModifier
{
    public RespawnPoint lastRespawn;
    public HealthManager myHpManager;
    public int hpMax;

    public override void OnDie()
    {
        transform.position = lastRespawn.transform.position;
        myHpManager.ChangeHP(hpMax);
        string sceneActuelle = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneActuelle);
    }
}
