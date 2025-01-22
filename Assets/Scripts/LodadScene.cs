using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
    static string nextScene;
    [SerializeField] private Slider progressBar; // ��ũ�� ��(Slider)

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
        op.allowSceneActivation = false; // ���� �ε��� 90%���� �ε� �� ����

        float timer = 0f;
        while (!op.isDone)
        {
            yield return null;

            if (op.progress < 0.9f)
            {
                progressBar.value = op.progress; // Slider�� value ����
            }
            else
            {
                timer += Time.unscaledDeltaTime; // Time.unscaledDeltaTime ���
                progressBar.value = Mathf.Lerp(0.9f, 1f, timer); // Lerp�� �� �ε巴�� ��ȭ

                if (progressBar.value >= 1f)
                {
                    op.allowSceneActivation = true; // �� ��ȯ ���
                    yield break;
                }
            }
        }
    }
}
