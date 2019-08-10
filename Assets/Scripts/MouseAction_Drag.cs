using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAction_Drag : MonoBehaviour
{
    [SerializeField] Player_Ctrl player_ctrl;
    [SerializeField] float       limit_time;

    private bool  down;
    private float pos_x;


    void Update()
    {
        if (down)
        {
            float dif = Input.mousePosition.x - pos_x;

            player_ctrl.Run(dif);
        }
    }


    private IEnumerator Limit()
    {
        yield return new WaitForSeconds(limit_time);

        down = true;
    }


    public void Down()
    {
        pos_x = Input.mousePosition.x;

        StartCoroutine("Limit");
    }


    public void Up()
    {
        StopCoroutine("Limit");

        down  = false;
        pos_x = 0.0f;
    }
}