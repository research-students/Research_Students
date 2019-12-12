using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAction_Wing : MonoBehaviour
{
    private Enemy_Parts_Manager parts_manager;


    public void Init(Enemy_Parts_Manager enemy_parts_manager)
    {
        parts_manager = enemy_parts_manager;

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
            yield return new WaitForSeconds(4f);

            if (Random.Range(1, 10) <= 7)
            {
                if (Random.Range(0, 2) == 0)
                {
                    parts_manager.Action(2, 1);
                }
                else
                {
                    parts_manager.Action(2, 2);
                }
            }
            else
            {
                yield return null;
            }
        }
    }
}