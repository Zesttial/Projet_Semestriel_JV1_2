using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PorteEnigme : MonoBehaviour
{
    [Header("UI")]
    public GameObject canvasEnigme;
    public string nomSceneSuivante = "Level1";
    public int degatSiErreur = 20;

    private bool joueurAPortee = false;


    private void Update()
    {
        if (joueurAPortee && Input.GetKeyDown(KeyCode.E))
        {
            OuvrirInterface();
        }
    }

    void OuvrirInterface()
    {
        canvasEnigme.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Repondre(bool estCorrect)
    {
        if(estCorrect)
        {
            Debug.Log("Bravo ! Passage autorisé.");
            Time.timeScale = 1f;
            SceneManager.LoadScene(nomSceneSuivante);
        }
        else
        {
            Debug.Log("ERREUR !");
            //HealthManager.PrendreDegats(degatSiErreur);

            canvasEnigme.SetActive(false);
            Time.timeScale = 1f;
            Cursor.visible = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OuvrirInterface();
            //joueurAPortee = false;
            //canvasEnigme.SetActive(false);
            //Time.timeScale = 1f;
        }
    }
}
