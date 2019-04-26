using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_DragAction : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float friction;


    private float amount;


    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * amount * speed * Time.deltaTime);

        amount *= friction;
    }


    public void GetAmount(float _amount)
    {
        amount = _amount;
    }
}