using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
    static string nextScene;
    [SerializeField] private Slider progressBar; // 스크롤 바(Slider)

    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("Loading");
    }

    void Start()
    {
        StartCoroutine(LoadSceneProcess());
    }

    IEnumerator LoadSceneProcess()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false; // 씬의 로딩을 90%까지 로딩 후 멈춤

        float timer = 0f;
        while (!op.isDone)
        {
            yield return null;

            if (op.progress < 0.9f)
            {
                progressBar.value = op.progress; // Slider의 value 갱신
            }
            else
            {
                timer += Time.unscaledDeltaTime; // Time.unscaledDeltaTime 사용
                progressBar.value = Mathf.Lerp(0.9f, 1f, timer); // Lerp로 값 부드럽게 변화

                if (progressBar.value >= 1f)
                {
                    op.allowSceneActivation = true; // 씬 전환 허용
                    yield break;
                }
            }
        }
    }
}
