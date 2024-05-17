using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneReload
{
    // # + phím để thực hiện nhấn phím
    [MenuItem("Help/Restart Scene #R")]
    public static void reloadscene()
    {
        Scene currentscene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentscene.buildIndex);
    }

    [MenuItem("Help/Next Scene #N")]
    public static void LoadNextScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        int nextSceneIndex = currentScene.buildIndex + 1;
        // nếu nextSceneIndex < SceneManager thì load đến scene tiếp 
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }

    [MenuItem("Help/Previous Scene #P")]
    public static void LoadPreviousScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        int previousSceneIndex = currentScene.buildIndex - 1;
        // nếu previous dương thì load scene đó
        if (previousSceneIndex >= 0)
        {
            SceneManager.LoadScene(previousSceneIndex);
        }
    }

}
