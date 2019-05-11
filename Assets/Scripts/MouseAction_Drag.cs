using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAction_Drag : MonoBehaviour
{
    [SerializeField] PlayerAction_Run action;

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


    public void Down()
    {
        down = true;
        posX = Input.mousePosition.x;
    }


    public void Up()
    {
        down = false;
        posX = 0.0f;
    }
}