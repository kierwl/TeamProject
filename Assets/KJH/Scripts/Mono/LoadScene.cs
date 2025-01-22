using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void Retry()
    {
        LoadSceneManager.LoadScene("Main");
    }
    public void GoToStartScene()
    {
        LoadSceneManager.LoadScene("StartScene");
    }
}
