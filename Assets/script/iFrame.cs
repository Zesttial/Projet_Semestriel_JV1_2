using NUnit.Framework;
using System.Collections;
using UnityEngine;

public class iFrame : MonoBehaviour
{
    [Header("Iframes")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer SpriteRend;
    public DammageType dammage;
    public bool degat;

    private void Awake()
    {
        SpriteRend = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float Dammage)
    {
        if (dammage == DammageType.Spike & degat)
            {
            degat = false;
           // StartCoroutine(Invulnerability());
            }         
    }

    //private IEnumerator Invulnerability()
    //{
    //    Physics2D.IgnoreLayerCollision(8, 1);
    //    for (int i = 0; i < numberOfFlashes; i++)
    //    {
    //        SpriteRend.color = new Color(1f, 0f, 0f, 0.5f);
    //        yield return new WaitForSeconds(1);
    //        SpriteRend.color = Color.white;
    //        yield return new WaitForSeconds(1);

    //    }
    //    degat = true;

    //}
}
