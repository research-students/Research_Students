using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAction_Drag : MonoBehaviour
{
    [SerializeField] PlayerAction_Drag player;

    private bool    drag;
    private float   arrange;
    private Vector2 beginDrag;


    void Start()
    {
        // 画面サイズ違いでの速度の差をなくす
        arrange = 1242.0f / Screen.width;
    }


    void FixedUpdate()
    {
        if (drag)
        {
            player.GetAmount(arrange * (Input.mousePosition.x - beginDrag.x));
        }
    }


    public void BeginDrag()
    {
        drag      = true;
        beginDrag = Input.mousePosition;
    }


    public void EndDrag()
    {
        drag      = false;
        beginDrag = Vector2.zero;
    }
}