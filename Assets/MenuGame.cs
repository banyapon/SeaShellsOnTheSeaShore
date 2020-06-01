using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGame : MonoBehaviour
{
    public AudioSource EnterSFX;
    void Update(){
        if (Input.GetKeyUp(KeyCode.Return))
        {
            LoadScene("Game");
            EnterSFX.Play();
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
           Application.Quit();
        }
    }

    public void LoadScene(string sceneName)
    {
        //StartCoroutine(LoadSceneObject(sceneName));
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public IEnumerator LoadSceneObject(string sceneName)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        async.allowSceneActivation = false;

        // Loop เพื่อตรวจสอบว่าโหลด Object เสร็จหรือยัง
        while (!async.isDone)
        {
            // ทำการคำนวณ progress
            float progress = Mathf.Clamp01(async.progress / 0.9f);
            Debug.Log("Loading progress: " + (progress * 100).ToString("n0") + "%");

            // Loading completed
            if (progress == 1f)
            {
                async.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
