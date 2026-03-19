using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Splines;

public class ennemy1 : MonoBehaviour
{

    public SpriteRenderer mySpriteRenderer;
    public SplineAnimate mySplineAnimate;
    public HealthManager myHpManager;
    public int hpMax;
    void Start()
    {
        myHpManager.ChangeHP(hpMax);
        mySplineAnimate.Container = FindFirstObjectByType<SplineContainer>();
        mySplineAnimate.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}