using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_game : MonoBehaviour
{
    public string LevelName;

    public void LoadLevel()
    {
        SceneManager.LoadScene(LevelName);
    }
}