using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Destruction_Object")
        {
            Destruction_Object tmp = col.GetComponent<Destruction_Object>();

            // Playerが触れた時のみダメージを与える
            tmp.Life_Sub(transform.root.GetComponent<Player_Ctrl>().Get_Kick_Power(), transform.root.tag);
        }
    }
}