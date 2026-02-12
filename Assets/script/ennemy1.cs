using UnityEngine;
using UnityEngine.Splines;

public class ennemy1 : MonoBehaviour
{

    public SpriteRenderer mySpriteRenderer;
    public SplineAnimate mySplineAnimate;
    public HpManager myHpManager;
    public int HpMax;
    void Start()
    {
        myHpManager.maxHP = HpMax;
        mySplineAnimate.Container = FindFirstObjectByType<SplineContainer>();
        mySplineAnimate.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
