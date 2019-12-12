using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAction_Shield : MonoBehaviour
{
    /*private Enemy_Parts_Manager parts_manager;
    private Enemy_Ctrl          enemy_ctrl;
    private float               action_range_y;
    private float               action_range_z;*/


    public void Init(Enemy_Parts_Manager enemy_parts_manager)
    {
        /*parts_manager  = enemy_parts_manager;
        enemy_ctrl     = transform.root.GetComponent<Enemy_Ctrl>();
        action_range_y = 2f;
        action_range_z = 15f;

        StartCoroutine(Action());*/
    }


    //-------------
    // アクション
    //-------------
    /*private IEnumerator Action()
    {
        yield return null;

        while (true)
        {
            if (Mathf.Pow(enemy_ctrl.Get_Player().position.y - transform.position.y, 2) < Mathf.Pow(action_range_y, 2) &&
                Mathf.Pow(enemy_ctrl.Get_Player().position.z - transform.position.z, 2) < Mathf.Pow(action_range_z, 2))
            {
                yield return new WaitForSeconds(5f);

                GetComponent<Enemy_Ctrl>().Run_Enabled(false);

                parts_manager.Get_Parts(1).GetComponent<Parts_Shield>().Rush_Enabled(true);
                
                yield return new WaitForSeconds(3f);

                GetComponent<Enemy_Ctrl>().Run_Enabled(true);

                parts_manager.Get_Parts(1).GetComponent<Parts_Shield>().Rush_Enabled(false);
            }
            else
            {
                yield return null;
            }
        }
    }*/
}