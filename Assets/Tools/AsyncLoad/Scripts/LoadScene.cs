using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    string nextSceneName;
    // Start is called before the first frame update
    void Start()
    {
        nextSceneName = GameObject.Find("NextSceneInfo").GetComponent<NextSceneInfoSetting>().GetNextSceneName();
        SceneManager.MoveGameObjectToScene(GameObject.Find("NextSceneInfo"), SceneManager.GetActiveScene());
        StartCoroutine(LoadNextScene());
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForEndOfFrame();

        AsyncOperation async = SceneManager.LoadSceneAsync(nextSceneName);
        while(async.progress < 0.9f)
        {
            yield return null;
        }
        async.allowSceneActivation = true;
    }
}
