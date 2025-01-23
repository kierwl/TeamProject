using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{

    public void Retry()
    {
        SceneManager.LoadScene("Main");
        
    }
    public void GoToStartScene()
    {
        SceneManager.LoadScene("StartScene");
        
    }
}
