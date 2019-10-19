using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garage : MonoBehaviour
{
    [SerializeField] Data_Manager    data_manager;
    [SerializeField] RectTransform[] bodys;
    [SerializeField] RectTransform[] slots;
    [SerializeField] RectTransform[] stocks;


    void Start()
    {
        // パーツのセーブデータを読み込む
        string[] bp_names = data_manager.Load_Parts(Data_Manager.CATEGORY.BP, Data_Manager.STATE.NAME);
        string[] bp_lifes = data_manager.Load_Parts(Data_Manager.CATEGORY.BP, Data_Manager.STATE.LIFE);
        string[] sp_names = data_manager.Load_Parts(Data_Manager.CATEGORY.SP, Data_Manager.STATE.NAME);
        string[] sp_lifes = data_manager.Load_Parts(Data_Manager.CATEGORY.SP, Data_Manager.STATE.LIFE);
        string[] gp_names = data_manager.Load_Parts(Data_Manager.CATEGORY.GP, Data_Manager.STATE.NAME);
        string[] gp_lifes = data_manager.Load_Parts(Data_Manager.CATEGORY.GP, Data_Manager.STATE.LIFE);
        
        // パーツをセット
        Set_Parts(bodys,  bp_names, bp_lifes);
        Set_Parts(slots,  sp_names, sp_lifes);
        Set_Parts(stocks, gp_names, gp_lifes);
    }


    //-----------------
    // パーツをセット
    //-----------------
    public void Set_Parts(RectTransform[] rect, string[] names, string[] lifes)
    {
        for (int i = 0; i < rect.Length; i++)
        {
            if (names[i] == "___")
            {
                continue;
            }

            // セーブデータからパーツイメージを生成
            GameObject parts_image = Instantiate((GameObject)Resources.Load("Prefab/Parts_Image/" + names[i]));

            // 初期化してセット
            parts_image.GetComponent<Parts_Image>().Init(rect[i].GetChild(0), null, int.Parse(lifes[i]));
        }
    }


    //-------------
    // 状態を保存
    //-------------
    public void Save_State()
    {
        data_manager.Save_Parts(Data_Manager.CATEGORY.BP, Data_Manager.STATE.NAME, bodys);                
        data_manager.Save_Parts(Data_Manager.CATEGORY.BP, Data_Manager.STATE.LIFE, bodys);
        data_manager.Save_Parts(Data_Manager.CATEGORY.SP, Data_Manager.STATE.NAME, slots);
        data_manager.Save_Parts(Data_Manager.CATEGORY.SP, Data_Manager.STATE.LIFE, slots);
        data_manager.Save_Parts(Data_Manager.CATEGORY.GP, Data_Manager.STATE.NAME, stocks);
        data_manager.Save_Parts(Data_Manager.CATEGORY.GP, Data_Manager.STATE.LIFE, stocks);
    }
}