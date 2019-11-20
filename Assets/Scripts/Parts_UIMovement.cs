using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parts_UIMovement : MonoBehaviour
{
    [SerializeField] float limit_mag;
    [SerializeField] float return_speed;

    private GameObject other_parts;
    private bool       touch;

    
    void Update()
    {
        if (touch)
        {
            // UIをドラッグする
            transform.position = Input.mousePosition;
        }
        else
        {
            // 元の位置に戻る
            transform.localPosition *= 1f / return_speed;
        }
    }


    public void Down()
    {
        touch = true;
    }


    public void Up()
    {
        touch = false;

        if (other_parts == null)
        {
            return;
        }
        else
        {
            // ゴミ箱に触れていたら
            if (other_parts.name == "Garbage_Can")
            {
                transform.GetChild(0).GetComponent<Parts_Image>().Delete();
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        other_parts = other.gameObject; 
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        other_parts = null;
    }
}