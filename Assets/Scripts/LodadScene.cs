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
        SceneManager.LoadScene("Load");
    }

    void Start()
    {
        StartCoroutine(LoadSceneProcess());
    }

    IEnumerator LoadSceneProcess()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false; // 씬 전환을 멈추고 90%까지만 로드

        float timer = 0f;
        while (!op.isDone)
        {
            yield return null;

            if (op.progress < 0.9f)
            {
                // Slider의 값 업데이트
                progressBar.value = op.progress;
                Canvas.ForceUpdateCanvases(); // UI 강제 갱신
            }
            else
            {
                timer += Time.unscaledDeltaTime;
                progressBar.value = Mathf.Lerp(0.9f, 1f, timer); // Lerp로 부드럽게 변화

                // Slider 값이 1이 되면 씬을 활성화
                if (progressBar.value >= 1f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
                Canvas.ForceUpdateCanvases(); // UI 강제 갱신
            }

            // UI 업데이트를 매 프레임마다 강제로 갱신
            yield return new WaitForEndOfFrame();
        }
    }

}
