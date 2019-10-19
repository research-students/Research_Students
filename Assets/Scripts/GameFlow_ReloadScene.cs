using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFlow_ReloadScene : MonoBehaviour
{
    public void Reload()
    {
        Time.timeScale = 1.0f;

        SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
    }
}