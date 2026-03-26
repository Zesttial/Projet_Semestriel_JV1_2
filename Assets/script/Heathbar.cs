using UnityEngine;
using UnityEngine.UI;

public class Heathbar : HpModifier
{
    public Image HealthBar;

    public override void OnHpChanged(int amount)
    {
        HealthBar.fillAmount = (float)amount/(float)healthManager.MaxHp();
    }
}
