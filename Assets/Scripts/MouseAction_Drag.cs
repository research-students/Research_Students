using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAction_Drag : MonoBehaviour
{
    [SerializeField] PlayerAction_Run action;
    [SerializeField] float            limit_time;

    private bool  down;
    private float posX;


    void Update()
    {
        if (down)
        {
            float dif = Input.mousePosition.x - posX;

            action.Drag(dif);
        }
    }


    private IEnumerator Limit()
    {
        yield return new WaitForSeconds(limit_time);

        down = true;
    }


    public void Down()
    {
        posX = Input.mousePosition.x;

        StartCoroutine("Limit");
    }


    public void Up()
    {
        StopCoroutine("Limit");

        down = false;
        posX = 0.0f;
    }
}