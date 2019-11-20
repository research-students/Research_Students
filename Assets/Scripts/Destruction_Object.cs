using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction_Object : MonoBehaviour
{
    [SerializeField] float life;


    //-----------------
    // ライフを減らす
    //-----------------
    public void Life_Sub(float damage, string parent_tag)
    {
        if (parent_tag == "Player" || parent_tag == "Player_Attack")
        {
            life -= damage;

            if (life <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}