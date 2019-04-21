using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFlow_LoadScene : MonoBehaviour
{
    [SerializeField] string sceneName;


    public void Load()
    {
        SceneManager.LoadScene(sceneName);
    }
}