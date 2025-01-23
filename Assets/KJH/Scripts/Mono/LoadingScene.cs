using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
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
