using UnityEngine;
using UnityEngine.SceneManagement;

public class CinemaToTuto : MonoBehaviour
{
    public float tempsDeLaCinematique = 82f;
    public string nomDeLaSceneTuto = "SampleScene";

    private void Start()
    {
        Invoke("PasserAuTuto", tempsDeLaCinematique);
    }

    void PasserAuTuto()
    {
        SceneManager.LoadScene(nomDeLaSceneTuto);
    }
}
