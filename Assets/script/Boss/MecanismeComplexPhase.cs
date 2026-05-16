using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MecanismeComplexPhase : MonoBehaviour
{
    public enum BossPhase
    {
        Phase1_Pics,
        Phase2_Chalumeaux,
        Phase3_Nuage,
        Dead,
    }

    [Header("Santé & Phase")]
    public float maxHealth = 200f;
    private float currentHealth;
    public BossPhase currentPhase = BossPhase.Phase1_Pics;

    [Header("Phase 1 : Pics")]
    public GameObject spikesPrefab;
    public Transform[] spikesSpawnPoints;

    [Header("Phase 2 : Chalumeaux & Caisses")]
    public GameObject chalumeauSustem;
    public GameObject caissePrefab;
    public Transform[] caisseSpawnPoints;

    [Header("Phase 3 : Nuage & Plateformes")]
    public GameObject toxicGasZone;
    public GameObject plateformSystem;

    private List<GameObject> spawnedObjects = new List<GameObject>();

    private void Start()
    {
        currentHealth = maxHealth;

        StartCoroutine(BossBehaviorLoop());
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentPhase = BossPhase.Dead;
            CleanEnvironment();
            if (toxicGasZone != null)
                toxicGasZone.SetActive(false);
            if(plateformSystem  != null)
                plateformSystem.SetActive(false);
            Debug.Log("Boss Final Vaincu !");
            Destroy(gameObject);
        }
        else if (currentHealth <= maxHealth * 0.33f && currentPhase != BossPhase.Phase3_Nuage)
        {
            currentPhase = BossPhase.Phase3_Nuage;
        }
        else if (currentHealth <= maxHealth * 0.66f && currentPhase == BossPhase.Phase1_Pics)
        { 
            currentPhase = BossPhase.Phase2_Chalumeaux;
        }
    }

    void CleanEnvironment()
    {
        foreach (GameObject obj in spawnedObjects)
        {
            if (obj != null) Destroy(obj);
        }
        spawnedObjects.Clear();
    }


    IEnumerator BossBehaviorLoop()
    {
        while(currentPhase != BossPhase.Dead)
        {
            CleanEnvironment();

            switch (currentPhase)
            {
                case BossPhase.Phase1_Pics:
                    yield return StartCoroutine(LogicPhase1Pics());
                    break;

                case BossPhase.Phase2_Chalumeaux:
                    yield return StartCoroutine(LogicPhase2Chalumeaux());
                    break;

                case BossPhase.Phase3_Nuage:
                    yield return StartCoroutine(LogicPhase3Nuage());
                    break;
            }
            yield return new WaitForSeconds(1f);
        }
    }


    IEnumerator LogicPhase1Pics()
    {
        Debug.Log("P1 - vague A : Pics sur un point sur deux !");

        for (int i = 0;  i < spikesSpawnPoints.Length; i++)
        {
            if (i % 2 ==0)
            {
                GameObject spikes = Instantiate(spikesPrefab, spikesSpawnPoints[i].position, transform.rotation);
                spawnedObjects.Add(spikes);
            }
        }
        yield return new WaitForSeconds(2.5f);
        CleanEnvironment();
        yield return new WaitForSeconds(0.5f);

        Debug.Log("P1 - vague B : Pics sur l'autre moitié ! Sors de là !");

        for (int i = 0; i < spikesSpawnPoints.Length; i++)
        {
            if (i % 2 != 0)
            {
                GameObject spikes = Instantiate(spikesPrefab, spikesSpawnPoints[i].position, transform.rotation);
                spawnedObjects.Add(spikes);
            }
        }
        yield return new WaitForSeconds(2.5f);
        CleanEnvironment();
        yield return new WaitForSeconds(0.5f);

        Debug.Log("P1 - vague C : Toute la salle ! Trouve la zone safe !");

        int safeZoneIndex = Random.Range(0, spikesSpawnPoints.Length);
        for (int i = 0; i< spikesSpawnPoints.Length; i++)
        {
            if(i !=safeZoneIndex)
            {
                GameObject spikes = Instantiate(spikesPrefab,spikesSpawnPoints[i].position, transform.rotation);
                spawnedObjects.Add(spikes);
            }
        }
        yield return new WaitForSeconds(3.5f);
        CleanEnvironment();
        yield return new WaitForSeconds(1.5f);
    }

    IEnumerator LogicPhase2Chalumeaux()
    {
        Debug.Log("P2 : Activation des chalumeaux et chute de caisse !");

        if(chalumeauSustem != null)
        {
            chalumeauSustem.SetActive(true);
        }
        int randomIndex = Random.Range(0,caisseSpawnPoints.Length);
        GameObject caisse = Instantiate(caissePrefab,caisseSpawnPoints[randomIndex].position, transform.rotation);
        spawnedObjects.Add(caisse);

        yield return new WaitForSeconds(6f);
    }


    IEnumerator LogicPhase3Nuage()
    {
        Debug.Log("P3 : Le gaz toxique se répand ! monter sur les plateformes !");

        if (chalumeauSustem != null)
            chalumeauSustem.SetActive(false);
        if (toxicGasZone != null)
            toxicGasZone.SetActive(true);
        if (plateformSystem != null)
            plateformSystem.SetActive(true);
        yield return new WaitForSeconds(10f);
    }




}
