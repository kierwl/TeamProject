using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
    static string nextScene;
    [SerializeField] private Slider progressBar;
    private static bool isSceneLoading = false;

    public static void LoadScene(string sceneName)
    {
        if (isSceneLoading) return; // 중복 호출 방지
        if (string.IsNullOrEmpty(sceneName))
        {
            Debug.LogError("Scene name is null or empty. Cannot load scene.");
            return;
        }

        isSceneLoading = true;
        nextScene = sceneName;
        SceneManager.LoadScene("Load");
    }

    void Start()
    {
        if (progressBar == null)
        {
            Debug.LogError("ProgressBar is not assigned.");
            return;
        }

        progressBar.value = 0f;
        StartCoroutine(LoadSceneProcess());
    }

    IEnumerator LoadSceneProcess()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;

        float timer = 0f;
        while (!op.isDone)
        {
            if (op.progress < 0.9f)
            {
                progressBar.value = op.progress;
            }
            else
            {
                timer += Time.unscaledDeltaTime;
                progressBar.value = Mathf.Lerp(0.9f, 1f, timer);

                if (progressBar.value >= 1f)
                {
                    op.allowSceneActivation = true;
                }
            }

            yield return null;
        }

        isSceneLoading = false; // 플래그 리셋
    }
}
