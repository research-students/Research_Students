using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parts_Attacher : MonoBehaviour
{
    [SerializeField] Player_Ctrl player;


    //----------------
    // アタッチ : UI
    //----------------
    public void Attach(string parts_name, Transform parts_changer, int life = 0)
    {
        if (player.Get_Death()) return;

        // パーツイメージを生成
        GameObject parts_image = Instantiate((GameObject)Resources.Load("Prefab/Parts_Image/" + parts_name));

        // 初期化してアタッチ
        parts_image.GetComponent<Parts_Image>().Init(parts_changer, transform, life);
    }
}