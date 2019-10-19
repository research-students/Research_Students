using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFlow_LoadScene : MonoBehaviour
{
    [SerializeField] string sceneName;
    [SerializeField] float  limit_time;
    [SerializeField] float  limit_dis;

    private Vector2 tap_pos;
    private bool    can_load;


    public void Load()
    {
        Time.timeScale = 1.0f;

        SceneManager.LoadScene(sceneName);
    }


    public void Down()
    {
        tap_pos  = Input.mousePosition;
        can_load = true;

        StartCoroutine("Limit_Time");
    }


    public void Up()
    {
        if (can_load)
        {
            if (Vector2.Distance(tap_pos, Input.mousePosition) < limit_dis)
            {
                Load();
            }
        }
    }


    private IEnumerator Limit_Time()
    {
        yield return new WaitForSeconds(limit_time);

        can_load = false;
    }
}