using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction_Flick : MonoBehaviour
{
    [SerializeField] Transform ray_point;
    [SerializeField] float     jump_power;

    private Rigidbody rigid;


    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }


    //-----------
    // ジャンプ
    //-----------
    public void Up()
    {
        // Rayを生成 : 下方向に伸ばす
        Ray ray = new Ray(ray_point.position, -ray_point.up);

        // 何かに接地していたらジャンプ
        if (Physics.Raycast(ray, out RaycastHit hit, 0.2f))
        {
            rigid.AddForce((Vector3.up * jump_power) + rigid.velocity, ForceMode.Impulse);
        }
    }


    public void Down()
    {
        Debug.Log("下フリック");
    }


    public void Left()
    {
        Debug.Log("左フリック");
    }


    public void Right()
    {
        Debug.Log("右フリック");
    }


    //---------------------
    // フリックアクション
    //---------------------
    public void Flick(Vector2 _dir)
    {
        if (Mathf.Pow(_dir.y, 2) > Mathf.Pow(_dir.x, 2))
        {
            if (_dir.y > 0.0f)
            {
                Up();
            }
            else
            {
                Down();
            }
        }
        else
        {
            if (_dir.x < 0.0f)
            {
                Left();
            }
            else
            {
                Right();
            }
        }
    }
}