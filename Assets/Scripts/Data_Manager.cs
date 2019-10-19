using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data_Manager : MonoBehaviour
{
    private int[] num_type = { 4, 3, 20 };
    

    public enum CATEGORY
    {
        BP,
        SP,
        GP,
    }

    public enum STATE
    {
        NAME,
        LIFE
    }


    //-----------------
    // パーツをロード
    //-----------------
    public string[] Load_Parts(CATEGORY category, STATE state)
    {
        string[] data = new string[num_type[(int)category]];

        for (int i = 0; i < num_type[(int)category]; i++)
        {
            // キーをセット
            string key = category.ToString() + state.ToString() + i.ToString();
            
            // データの取得
            data[i] = PlayerPrefs.GetString(key);
        }

        return data;
    }


    //-----------------
    // パーツをセーブ
    //-----------------
    public void Save_Parts(CATEGORY category, STATE state, RectTransform[] data)
    {
        for (int i = 0; i < num_type[(int)category]; i++)
        {
            // キーをセット
            string key = category.ToString() + state.ToString() + i.ToString();

            if (data[i].GetChild(0).childCount == 0)
            {
                PlayerPrefs.SetString(key, "___");
            }
            else
            {
                // Partsを取得
                Parts_Image parts = data[i].GetChild(0).GetChild(0).GetComponent<Parts_Image>();

                // データの保存
                if (state == STATE.NAME)
                {
                    PlayerPrefs.SetString(key, parts.Get_Name());
                }
                else
                {
                    PlayerPrefs.SetString(key, parts.Get_Life().ToString());
                }
            }
        }
    }


    //---------
    // ロスト
    //---------
    public void Lost()
    {
        for (int i = 0; i < num_type[(int)CATEGORY.BP]; i++)
        {
            string key_name = CATEGORY.BP.ToString() + STATE.NAME.ToString() + i.ToString();
            string key_life = CATEGORY.BP.ToString() + STATE.LIFE.ToString() + i.ToString();

            PlayerPrefs.SetString(key_name, "___");
            PlayerPrefs.SetString(key_life, "___");
        }

        for (int i = 0; i < num_type[(int)CATEGORY.SP]; i++)
        {
            string key_name = CATEGORY.SP.ToString() + STATE.NAME.ToString() + i.ToString();
            string key_life = CATEGORY.SP.ToString() + STATE.LIFE.ToString() + i.ToString();

            PlayerPrefs.SetString(key_name, "___");
            PlayerPrefs.SetString(key_life, "___");
        }
    }
}