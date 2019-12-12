using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAction_Gun : MonoBehaviour
{
    private Enemy_Parts_Manager parts_manager;
    private Enemy_Ctrl          enemy_ctrl;
    private float               action_range_y;
    private float               action_range_z;


    public void Init(Enemy_Parts_Manager enemy_parts_manager)
    {
        parts_manager  = enemy_parts_manager;
        enemy_ctrl     = transform.root.GetComponent<Enemy_Ctrl>();
        action_range_y = 2f;
        action_range_z = 15f;

        StartCoroutine(Action());
    }


    //-------------
    // アクション
    //-------------
    private IEnumerator Action()
    {
        yield return null;

        while (true)
        {
            if (Mathf.Pow(enemy_ctrl.Get_Player().position.y - transform.position.y, 2) < Mathf.Pow(action_range_y, 2) &&
                Mathf.Pow(enemy_ctrl.Get_Player().position.z - transform.position.z, 2) < Mathf.Pow(action_range_z, 2))
            {
                yield return new WaitForSeconds(5f);
            
                parts_manager.Action(1, 1);
            }
            else
            {
                yield return null;
            }
        }
    }
}