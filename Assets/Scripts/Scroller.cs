using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour
{
    [SerializeField] RectTransform parent;
    [SerializeField] RectTransform scroll;
    [SerializeField] Scrollbar     scrollbar;
    [SerializeField] float         distance;
    [SerializeField] float         friction;

    private Vector2 tap_pos;
    private float   velocity;
    private bool    scrolling;


    void Start()
    {
        // スクロールバーのサイズ指定
        scrollbar.size = 1f / scroll.childCount;
    }

    void Update()
    {
        // スクロール1
        Scroll1((scrollbar.value - scrollbar.size) * (scroll.childCount * distance));

        if (Input.touchCount > 0 || Input.GetMouseButton(0))
        {
            if (!scrolling)
            {
                // スクロール2
                Scroll2((Input.mousePosition.y - tap_pos.y) / ((scroll.childCount * distance) - distance));
            }
        }
        else
        {
            // 慣性
            scrollbar.value += velocity;
        }

        // スクロールの調整
        Scroll_Adjust((1f - scrollbar.value) * distance);

        // 位置の更新
        tap_pos = Input.mousePosition;

        // 加速度の減速
        velocity *= friction;
    }


    //--------------
    // スクロール1
    //--------------
    private void Scroll1(float amount)
    {
        parent.localPosition = Vector2.up * amount;
    }


    //--------------
    // スクロール2
    //--------------
    private void Scroll2(float amount)
    {
        velocity         = amount;
        scrollbar.value += amount;
    }


    //-------------------
    // スクロールの調整
    //-------------------
    private void Scroll_Adjust(float amount)
    {
        scroll.localPosition = Vector2.up * amount;
    }


    //-----------------
    // バーを押したら
    //-----------------
    public void Down()
    {
        scrolling = true;
    }


    //-----------------
    // バーを離したら
    //-----------------
    public void Up()
    {
        scrolling = false;
    }
}