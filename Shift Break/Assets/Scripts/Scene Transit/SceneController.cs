using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{

    public static int currentSceneIndex = 0;

    public static int getCurrentSceneIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadScene(int index)
    {
        ResumeScene();
        SceneManager.LoadScene(index);
        currentSceneIndex = index;
    }

    public static void PauseScene()
    {
        Time.timeScale = 0.0f;
    }

    public static void ResumeScene()
    {
        Time.timeScale = 1.0f;
    }

}
