using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private bool _isLoading = false;

    private AsyncOperation _loadingOperation = null;

    private void Start()
    {
        //LoadSceneAdditive("Outdoor 1");
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void LoadSceneAdditiveAsync(string scene)
    {
        StartCoroutine(AsynchronousLoad(scene));
    }

    public void ActivateLoadedAdditiveScene()
    {
        if (_loadingOperation is null) return;

        // Loading completed
        if (_loadingOperation.progress == 0.9f)
        {
            _loadingOperation.allowSceneActivation = true;
        }

        _loadingOperation = null;
    }

    private IEnumerator AsynchronousLoad(string scene)
    {
        _isLoading = true;

        yield return null;

        var previousScene = SceneManager.GetActiveScene();

        //if (SceneManager.GetSceneByName(scene).isLoaded)
        //{
        //    SceneManager.GetSceneByName(scene).
        //}

        _loadingOperation = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
        _loadingOperation.allowSceneActivation = false;

        while (_loadingOperation.progress < 0.9f)//(!_loadingOperation.isDone)
        {
            // [0, 0.9] > [0, 1]
            float progress = Mathf.Clamp01(_loadingOperation.progress / 0.9f);
            Debug.Log($"Scene loading progress: {progress * 100}%");

            // Loading completed
            //if (_loadingOperation.progress == 0.9f)
            //{
            //    Debug.Log("Press a key to start");
            //    if (Input.anyKey)
            //    {
            //        _loadingOperation.allowSceneActivation = true;
            //        //Time.timeScale = 1;
            //    }

            //}

            yield return null;
        }
        Debug.Log("Loaded");
        _isLoading = false;
    }
}
