using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFlow_CoverScene : MonoBehaviour
{
    [SerializeField] string sceneName;

    private bool covered;


    public void Cover()
    {
        if (!covered)
        {
            Time.timeScale = 0.0f;

            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        }
        else
        {
            Time.timeScale = 1.0f;

            SceneManager.UnloadSceneAsync(sceneName);
        }

        covered = !covered;
    }
}